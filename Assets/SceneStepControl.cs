using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStepControl : MonoBehaviour
{
    // Start is called before the first frame update
    public player_move_in_book_one player_movement;
    public GameObject flashlight;
    public ropeSystem ropeSystem;
    public Fungus.Flowchart story_flowchart;

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "window_spot")
        {
            story_flowchart.ExecuteBlock("escape_barn");
            // Destroy(this.gameObject.GetComponent<Rigidbody2D>());
            Color oringinal_color = this.gameObject.GetComponent<SpriteRenderer>().color;
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(oringinal_color, new Color(255f, 255f, 255f, 0.1f), Mathf.PingPong(Time.time, 3));
        }
    }
    //private void OnTriggerEnter2D(Collider collision)
    //{
    //    if (collision.name == "window_spot")
    //    {
    //        Color oringinal_color = this.gameObject.GetComponent<SpriteRenderer>().color;
    //        this.gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(oringinal_color, new Color(255f, 255f, 255f, 0.1f), Mathf.PingPong(Time.time, 3));
    //    }
    //}
}
