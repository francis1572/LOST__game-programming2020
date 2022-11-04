using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private List<Vector3> vectorDirection = new List<Vector3>() { new Vector3(1, 0, 0), new Vector3(0, 1, 0) };
    private int index;
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.gameObject.transform.position += vectorDirection[index]*speed;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.transform.position -= vectorDirection[index] * speed;
        }
    }
    public void pick_left_road()
    {
        //create rotation
        indexChange();
        Quaternion wantedRotation = new Quaternion(0,0,1f,1);
        //then rotate
        this.gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, wantedRotation, 1);  
    }
    public void pick_right_road()
    {
        //create rotation
        indexChange();
        Quaternion wantedRotation = new Quaternion(0, 0, -1f, 1);
        //then rotate
        this.gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, wantedRotation, 1);
    }
    public void indexChange()
    {
        if (index == 0)
        {
            index = 1;
        }
        else if(index == 1)
        {
            index = 0;
        }
    }
}
