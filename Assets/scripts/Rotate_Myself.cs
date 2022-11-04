using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Myself : MonoBehaviour
{
    public int Rotate_X;
    public int Rotate_Y;
    public int Rotate_Z;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Rotate_X, Rotate_Y, Rotate_Z);
    }
}
