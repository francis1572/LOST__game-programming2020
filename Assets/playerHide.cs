using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHide : MonoBehaviour
{
    public Fungus.Flowchart story_flowchart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "flashlight")
        {
            GameObject.Find("wasFoundSound").GetComponent<AudioSource>().Play();
            StartCoroutine(get_caught());
        }
    }
    public IEnumerator get_caught()
    {
        story_flowchart.SendFungusMessage("caught_player");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("firstbook_village");
    }
}
