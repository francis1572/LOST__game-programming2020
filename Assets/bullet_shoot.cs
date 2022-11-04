using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_shoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }
    public void shoot()
    {
        Vector3 robber_pos = GameObject.Find("robber1").transform.position;
        this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, robber_pos, 0.3f);
    }
}
