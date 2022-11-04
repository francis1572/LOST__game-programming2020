using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss_collision : MonoBehaviour
{
    public float Boss_Life_Num;
    //public GameObject Explosion;
    public Slider boss_hp;
    public GameObject Fill_Area;
    public GameObject controller3;
    public GameObject controller_hp;
    public GameObject boss_hit;
    public GameObject player;

    public AudioClip hurtSound;
    public Fungus.Flowchart flowchart;


    // Start is called before the first frame update
    void Start()
    {
        //Boss_Life_Num = 200;
    }

    // Update is called once per frame
    void Update()
    {
        boss_hp.value = Boss_Life_Num;
        if (Boss_Life_Num < 0.09)
        {
            Fill_Area.SetActive(false);
            Destroy(controller3, 0);
            Destroy(controller_hp, 0);
            gameObject.SetActive(false);
            flowchart.ExecuteBlock("win");
            player.GetComponent<player_move>().enabled = false;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player_tri")
        {
            Boss_Life_Num -= 5f;
            GetComponent<AudioSource>().PlayOneShot(hurtSound, 0.25f);
            StartCoroutine(Alpha());

            //Instantiate(Explosion, collision.transform.position, collision.transform.rotation);
            //Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "player_pencil")
        {
            Boss_Life_Num -= 6f;
            GetComponent<AudioSource>().PlayOneShot(hurtSound, 0.25f);
            StartCoroutine(Alpha());
            //Instantiate(Explosion, collision.transform.position, collision.transform.rotation);
            //Destroy(collision.gameObject);
        }


    }

    IEnumerator Alpha()
    {
        Instantiate(boss_hit, new Vector3(33.54f, 11.1f, 1f), new Quaternion(0, 0, 0, 0));
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
    }
}
