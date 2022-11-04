using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robber_dead : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void dead()
    {
        GameObject.Find("robber2").transform.position += new Vector3(2, 0, 0);
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
        this.gameObject.transform.position += new Vector3(0, -3, 0);


    }
}
