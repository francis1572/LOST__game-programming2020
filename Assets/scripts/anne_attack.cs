using UnityEngine;
using System.Collections;
using Fungus;

public class anne_attack : MonoBehaviour
{
    public AudioClip sad_melody;
    private GameObject bullet_1;
    private GameObject bullet_2;
    private GameObject bullet_3;
    private GameObject jack;
    private GameObject mask;
    private GameObject pump;
    private GameObject pumpkin;
    private int count;
    private GameObject player;
    private GameObject light;

    // Use this for initialization
    void Start()
    {
        bullet_1 = GameObject.Find("bullet_1");
        bullet_2 = GameObject.Find("bullet_2");
        bullet_3 = GameObject.Find("bullet_3");
        jack = GameObject.Find("Jack");
        mask = GameObject.Find("Mask");
        pump = GameObject.Find("pump");
        pumpkin = GameObject.Find("pumpkin");
        player = GameObject.Find("player");
        count = 0;
        light = GameObject.Find("light");

        light.transform.SetParent(pump.transform);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void object_set()
    {
        bullet_1.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
        bullet_2.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
        bullet_3.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
        Destroy(jack);
        GameObject.Find("lightBallSound").GetComponent<AudioSource>().Play();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "player" && count == 0)
        {
            GameObject.Find("lightBallSound").GetComponent<AudioSource>().Stop();
            GameObject.Find("bgm").GetComponent<AudioSource>().Stop();
            Destroy(bullet_1);
            Destroy(bullet_2);
            Destroy(bullet_3);
            Flowchart.BroadcastFungusMessage("rescue");
            mask.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            count += 1;
            StartCoroutine(backToMainTheme());
        }
    }

    private void pumpkin_head()
    {
        player.gameObject.GetComponent<player_move>().enabled = false;
        player.transform.position = new Vector3(9, -2.92f, 0);
        pump.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 11;
        pump.transform.position = new Vector3(11.51f, -1.25f, 0);
        pump.transform.SetParent(transform);
        Destroy(pumpkin);
    }
    private void reverse()
    {
        mask.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        Flowchart.BroadcastFungusMessage("ghost");
    }
    private void transform_anne()
    {
        player.transform.position = new Vector3(-10.96f, -2.92f, 0);
        transform.position = new Vector3(-5, -2.88f, 0);
    }
    private void dark()
    {
        mask.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
    }
    private void bright()
    {
        mask.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
    }

    IEnumerator Fadeout()
    {
        for(float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = transform.gameObject.GetComponent<SpriteRenderer>().color;
            c.a = f;
            transform.gameObject.GetComponent<SpriteRenderer>().color = c;
            pump.transform.gameObject.GetComponent<SpriteRenderer>().color = c;
            //light.transform.gameObject.GetComponent<SpriteRenderer>().color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void start_fading()
    {
        Destroy(light);
        StartCoroutine("Fadeout");
    }

    IEnumerator backToMainTheme()
    {
        yield return new WaitForSeconds(1f);
        GameObject.Find("bgm").GetComponent<AudioSource>().clip = sad_melody;
        GameObject.Find("bgm").GetComponent<AudioSource>().Play();
    }
}
