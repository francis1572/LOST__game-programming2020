using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public player_move_in_book_one player_movement;
    public GameObject flashlight;
    public ropeSystem ropeSystem;
    public 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void start_player_movement()
    {
        player_movement.enabled = true;
        flashlight.transform.SetParent(this.gameObject.transform);

    }
    public void start_rope_system()
    {
        ropeSystem.enabled = true;
    }
}
