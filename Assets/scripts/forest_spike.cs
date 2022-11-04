using UnityEngine;
using System.Collections;
using Fungus;

public class forest_spike : MonoBehaviour
{
    private GameObject player;
    private int count;
    private bool spike_touch_1;
    private bool spike_touch_2;
    private bool spike_touch_3;
    private bool spike_touch_4;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("player");
        count = -1;
        spike_touch_1 = false;
        spike_touch_2 = false;
        spike_touch_3 = false;
        spike_touch_4 = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (transform.name == "spike2_1" && spike_touch_1 == false)
            {
                player.gameObject.GetComponent<player_move>().enabled = false;
                player.transform.position = new Vector3(33.44f, -10.129f, 0f);
                count = 180;
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
                spike_touch_1 = true;
                Flowchart.BroadcastFungusMessage("hurt");
            }
            else if(transform.name == "spike2_1" && spike_touch_1){
                player.gameObject.GetComponent<player_move>().enabled = false;
                player.transform.position = new Vector3(33.44f, -10.129f, 0f);
                Flowchart.BroadcastFungusMessage("hurt again");
            }

            if (transform.name == "spike2_2" && spike_touch_2 == false)
            {
                player.gameObject.GetComponent<player_move>().enabled = false;
                player.transform.position = new Vector3(33.44f, -10.129f, 0f);
                count = 180;
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
                spike_touch_2 = true;
                Flowchart.BroadcastFungusMessage("hurt");
            }
            else if (transform.name == "spike2_2" && spike_touch_2)
            {
                player.gameObject.GetComponent<player_move>().enabled = false;
                player.transform.position = new Vector3(33.44f, -10.129f, 0f);
                Flowchart.BroadcastFungusMessage("hurt again");
            }

            if (transform.name == "spike2_3" && spike_touch_3 == false)
            {
                player.gameObject.GetComponent<player_move>().enabled = false;
                player.transform.position = new Vector3(33.44f, -10.129f, 0f);
                count = 180;
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, 0); 
                spike_touch_3 = true;
                Flowchart.BroadcastFungusMessage("hurt");
            }
            else if (transform.name == "spike2_3" && spike_touch_3)
            {
                player.gameObject.GetComponent<player_move>().enabled = false;
                player.transform.position = new Vector3(33.44f, -10.129f, 0f);
                Flowchart.BroadcastFungusMessage("hurt again");
            }

            if (transform.name == "spike2_4" && spike_touch_4 == false)
            {
                player.gameObject.GetComponent<player_move>().enabled = false;
                player.transform.position = new Vector3(33.44f, -10.129f, 0f);
                count = 180;
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
                spike_touch_4 = true;
                Flowchart.BroadcastFungusMessage("hurt");
            }
            else if (transform.name == "spike2_4" && spike_touch_4)
            {
                player.gameObject.GetComponent<player_move>().enabled = false;
                player.transform.position = new Vector3(33.44f, -10.129f, 0f);
                Flowchart.BroadcastFungusMessage("hurt again");
            }

        }

       
    }
}
