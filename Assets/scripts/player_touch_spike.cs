using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Fungus;

[RequireComponent(typeof(AudioSource))]
public class player_touch_spike : MonoBehaviour
{
    public float Player_Life_Num;
    public Slider player_hp;
    public GameObject Fill_Area;
    public AudioClip touchSpike;
    public static Flowchart talkFlowchart;

    // Use this for initialization
    void Start()
    {
        Player_Life_Num = 100;
        talkFlowchart = GameObject.FindGameObjectWithTag("talkFlowchart").GetComponent<Flowchart>();
    }

    // Update is called once per frame
    void Update()
    {
        player_hp.value = Player_Life_Num;
        if (Player_Life_Num < 0.09)
        {
            Fill_Area.SetActive(false);
            //Destroy(gameObject, 0.2f);
            talkFlowchart.ExecuteBlock("dead");
            gameObject.GetComponent<player_move>().enabled=false;
        }

        Color tmp = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = tmp;
        tmp.a = 125;
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "spike")
    //    {
    //        Player_Life_Num -= 5 * Time.deltaTime;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D trigger_collision)
    {
        if (trigger_collision.gameObject.tag == "spear")
        {
            Player_Life_Num -= 7.5f;
            InvokeRepeating("hurt", 0, 1.5f);
        }
        else if (trigger_collision.gameObject.tag == "spike")
        {
            Player_Life_Num -= 2.5f;
            InvokeRepeating("hurt", 0, 1.5f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "spike" || collision.gameObject.tag == "spear")
        {
            Player_Life_Num -= 1.5f * Time.deltaTime;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "spike" || collision.gameObject.tag == "spear")
        {
            CancelInvoke("hurt");
        }
    }

    private void hurt()
    {
        GetComponent<AudioSource>().PlayOneShot(touchSpike, 0.7f);
    }

    IEnumerator Alpha()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
    }
}
