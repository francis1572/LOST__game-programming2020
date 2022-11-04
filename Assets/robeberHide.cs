using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robeberHide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void hide()
    {
        GameObject.Find("robber1").transform.position = new Vector3(22, -4.5f, 0);
        GameObject.Find("robber2").transform.position = new Vector3(24, -4.5f, 0);

    }
}
