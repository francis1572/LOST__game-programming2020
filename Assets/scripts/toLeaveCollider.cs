using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class toLeaveCollider : MonoBehaviour
{
    public static Flowchart talkFlowchart;
    public GameObject player;
    private bool locked=false;
    // Start is called before the first frame update
    void Start()
    {
        talkFlowchart = GameObject.FindGameObjectWithTag("talkFlowchart").GetComponent<Flowchart>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerFreeze==false && locked == true)
        {
            player.GetComponent<player_move>().enabled = true;
            locked =false;
        }
        if (historyHigan)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (historyHigan2)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        talkFlowchart.ExecuteBlock("hit leave collider");
        player.GetComponent<player_move>().enabled = false;
        locked = true;
    }
    public static bool playerFreeze
    {
        get { return talkFlowchart.GetBooleanVariable("freeze"); }
    }

    public static bool historyHigan2
    {
        get { return talkFlowchart.GetBooleanVariable("history_higan2"); }
    }
    public static bool historyHigan
    {
        get { return talkFlowchart.GetBooleanVariable("history_higan"); }
    }
}
