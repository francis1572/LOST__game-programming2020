using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plead : MonoBehaviour
{
    // Start is called before the first frame update
    public Fungus.Flowchart story_flowchart;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(story_flowchart.GetBooleanVariable("dad_died"))
        {
            run_to_mom();
        }
    }
    public void run_to_mom()
    {
        Vector3 dead_pos = GameObject.Find("robber1").transform.position + new Vector3(-3, 2, 0);
        this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, dead_pos, 0.02f);
    }
}
