using UnityEngine;
using System.Collections;
using Fungus;

public class forest_transport_start : MonoBehaviour
{
    private GameObject jack;
    private GameObject mask;
    private int count;
    public GameObject originBgm;
    public GameObject forestBgm;
    public GameObject cityBgm;
    public GameObject waterfallBgm;
    // Use this for initialization
    void Start()
    {
        jack = GameObject.Find("Jack");
        mask = GameObject.Find("Mask");
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void transfer()
    {   
        //transform.localScale = new Vector3(18.29f, -10f, 1);
        Camera.main.GetComponent<CameraFollow>().maxXAndY = new Vector2(32.16f, -8.44f);
        Camera.main.GetComponent<CameraFollow>().minXAndY = new Vector2(13f, -8.98f);
        transform.position = new Vector3(33.44f, -10.129f, 0f);

        jack.transform.position = new Vector3(transform.position.x + 1f, transform.position.y, 0);
        jack.transform.SetParent(transform);

        originBgm.GetComponent<AudioSource>().Stop();
        forestBgm.GetComponent<AudioSource>().Play();

        Flowchart.BroadcastFungusMessage("first scene");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "port") {
            //Debug.Log("kjixdix");
            mask.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
            Flowchart.BroadcastFungusMessage("switch scene");
        }

        if (collision.gameObject.name == "port2")
        {
            //Debug.Log("kjixdix");
            mask.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
            Flowchart.BroadcastFungusMessage("switch scene2");
        }
    }
    private void transfer2()
    {
        //transform.localScale = new Vector3(18.29f, -10f, 1);
        Camera.main.GetComponent<CameraFollow>().maxXAndY = new Vector2(-10.34f, 6.06f);
        Camera.main.GetComponent<CameraFollow>().minXAndY = new Vector2(-12.67f, 6.06f);
        transform.position = new Vector3(-8.14f, 4.91f, 1);
        forestBgm.GetComponent<AudioSource>().Stop();
        waterfallBgm.GetComponent<AudioSource>().Play();

    }
    private void transfer3()
    {
        //transform.localScale = new Vector3(18.29f, -10f, 1);
        Camera.main.GetComponent<CameraFollow>().maxXAndY = new Vector2(17.58f, 6.12f);
        Camera.main.GetComponent<CameraFollow>().minXAndY = new Vector2(14.38f, 6.12f);
        transform.position = new Vector3(16.83f, 4.88f, 1);
        waterfallBgm.GetComponent<AudioSource>().Stop();
        cityBgm.GetComponent<AudioSource>().Play();
    }

    private void enable_script()
    {
        gameObject.GetComponent<player_move>().enabled = false;
    }
    private void able_script()
    {
        gameObject.GetComponent<player_move>().enabled = true;
    }
}
