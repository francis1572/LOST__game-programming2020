using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeParent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void remove_parent()
    {
        this.gameObject.transform.SetParent(null);
    }
}
