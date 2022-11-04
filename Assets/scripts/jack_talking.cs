using UnityEngine;
using System.Collections;
using Fungus;

public class jack_talking : MonoBehaviour
{
    private GameObject bag;
    private GameObject wagon;

    // Use this for initialization
    void Start()
    {
        bag = GameObject.Find("pumpkin_bag");
        wagon = GameObject.Find("wagon");
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (wagon.transform.position.x == -13.14f)
        {
            Flowchart.BroadcastFungusMessage("hint");
        }
        else if(wagon.transform.position.x != -13.14f)
        {
            //Debug.Log(wagon.transform.position.x);
            Flowchart.BroadcastFungusMessage("anne");
        }
    }
}
