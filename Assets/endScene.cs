using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class endScene : MonoBehaviour
{
    // Start is called before the first frame update
    public Fungus.Flowchart story_flowchart;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "destination")
        {

            story_flowchart.ExecuteBlock("end");
        }
    }
}
