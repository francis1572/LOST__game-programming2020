using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_collision_in_book_one : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(1, 0, 0);
        }
        
    }
    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "rope")
    //    {
    //        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
    //        yield return new WaitForSeconds(1);
    //        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
    //        //transform.position = Vector3.Lerp(transform.position, collision.transform.position, Time.deltaTime);
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "rope")
        {
            //gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            //yield return new WaitForSeconds(0.1f);
            //gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            //Physics2D.gravity = Vector2.zero;
            
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0, 0);
            //transform.position = Vector3.Lerp(transform.position, collision.transform.position, Time.deltaTime);

        }
    }
}
