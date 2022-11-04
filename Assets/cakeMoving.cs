using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cakeMoving : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private Vector3 initial_position;
    void Start()
    {
        player = GameObject.Find("player");
        Vector3 initial_position = player.transform.position;
        this.gameObject.transform.position = initial_position + new Vector3(-0.3f, 2.7f,0);
        this.gameObject.transform.SetParent(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
