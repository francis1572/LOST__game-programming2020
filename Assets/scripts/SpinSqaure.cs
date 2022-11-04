using UnityEngine;
using System.Collections;

public class SpinSqaure : MonoBehaviour
{
    public float rotate_x;
    public float rotate_y;
    public float rotate_z;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.parent.gameObject.transform.RotateAround(transform.position, new Vector3(rotate_x, rotate_y, rotate_z), 30*Time.deltaTime);
    }
}
