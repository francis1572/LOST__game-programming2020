using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickObject : MonoBehaviour
{
    // Start is called before the first frame update
    public float x;
    public float y;
    public float max_dist;
    public Fungus.Flowchart story_flowchart;
    private bool able_pick;
    void Start()
    {
        able_pick = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pick_up()
    {
        if (story_flowchart.GetStringVariable("pick_object_name") != null && story_flowchart.GetStringVariable("pick_object_name") != "")
        {
            story_flowchart.ExecuteBlock("already_pick");
            return;
        }
        check_distance();
        if (able_pick == false)
        {
            story_flowchart.ExecuteBlock("too_far_to_pick");
            return;
        }
        story_flowchart.SetStringVariable("pick_object_name", this.gameObject.name);
        this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        this.gameObject.transform.SetParent(GameObject.Find("player").transform);
    }
    public void pick_down()
    {
        story_flowchart.SetStringVariable("pick_object_name", "");
        this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        this.gameObject.transform.SetParent(null);
        this.gameObject.transform.position = new Vector3(GameObject.Find("player").transform.position.x + 2, GameObject.Find("downCollider").transform.position.y, 0);
    }
    public void pick_dismiss()
    {
        story_flowchart.SetStringVariable("pick_object_name", "");
        this.gameObject.transform.SetParent(null);
        this.gameObject.transform.position = new Vector3(GameObject.Find("player").transform.position.x + 2, GameObject.Find("downCollider").transform.position.y, 0);
    }
    public void check_distance()
    {
        float dist = Vector3.Distance(this.gameObject.transform.position, GameObject.Find("player").transform.position);
        if(dist <= max_dist)
        {
            able_pick = true;
        }
        else
        {
            able_pick = false;
        }
    }
}
