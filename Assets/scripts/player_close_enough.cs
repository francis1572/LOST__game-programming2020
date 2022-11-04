using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_close_enough : MonoBehaviour
{
    public GameObject player;
    public float max_dist = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, this.gameObject.transform.position);
        if (dist < max_dist)
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
