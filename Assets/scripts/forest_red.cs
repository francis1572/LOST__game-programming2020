using UnityEngine;
using System.Collections;
using Fungus;

public class forest_red : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            Flowchart.BroadcastFungusMessage("meet red");
        }
    }
}
