using UnityEngine;
using System.Collections;

public class light_ball_hit : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "bullet_1" || collision.gameObject.name == "bullet_2" || collision.gameObject.name == "bullet_3")
        {
            transform.position = new Vector3(collision.gameObject.transform.position.x - 5f, transform.position.y, 0);
        }
    }
}
