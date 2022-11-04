using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly_move : MonoBehaviour
{
    // Start is called before the first frame update
    public float Move_Speed;
    public Vector3 dir;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (dir * Move_Speed);
    }
}
