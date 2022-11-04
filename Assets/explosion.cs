using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class explosion : MonoBehaviour
{
    // Start is called before the first frame update
    private bool on_rock;
    private int explodeCnt;
    private bool explodeSuccess;
    public Fungus.Flowchart prefab_flowchart;
    public Transform prefab;
    public GameObject hint;

    void Start()
    {
        on_rock = false;
        explodeCnt = 0;
        explodeSuccess = false;
        hint = GameObject.Find("hint");
    }

    // Update is called once per frame
    void Update()
    {
        explodeCnt += 1;
        if (transform.position.x >= 9.63f && transform.position.x <= 38.7f && transform.position.y >= -7.3f && transform.position.y <= 3.5f)
        {
            explodeSuccess = true;
        }

        if (explodeCnt == 1)
        {
            explode();
        }
    }
    public void explode()
    {
        StartCoroutine(count_down());
    }
    private IEnumerator count_down()
    {
        
        yield return new WaitForSeconds(7f);
        Instantiate(prefab, this.gameObject.transform.position + new Vector3(0, 5, 0), Quaternion.identity);
        //Debug.Log(explodeSuccess);
        if (explodeSuccess)
        {
            GameObject.Find("explodeSound").GetComponent<AudioSource>().Play();
            Destroy(hint);
            Destroy(GameObject.Find("stone"));
            Destroy(GameObject.Find("box(Clone)"));
            Destroy(this.gameObject);
        }
        else
        {
            GameObject.Find("explodeSound").GetComponent<AudioSource>().Play();
            //Destroy(GameObject.Find("stone"));
            Destroy(GameObject.Find("box(Clone)"));
            this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -11;
            prefab_flowchart.ExecuteBlock("explode");
            yield return new WaitForSeconds(1f);

            Destroy(this.gameObject);
            SceneManager.LoadScene("firstbook_village2");
        }
        yield return new WaitForSeconds(1.5f);
        Destroy(GameObject.FindGameObjectWithTag("explosion"));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.name == "stone")
        {
            on_rock = true;
        }
    }
}
