using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move_in_book_one : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rigid;
    public float speed;
    public Animator playerAni;
    public Transform groundCheck;
    public float distance;
    public LayerMask groundLayer;
    public bool grounded;
    public bool isClimbing;
    public Fungus.Flowchart story_flowchart;
    void Start()
    {
        isClimbing = false;

    }
    public bool JumpKey
    {
        get
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
    }
    bool IsGround
    {
        get
        {
            Vector2 start = groundCheck.position;
            Vector2 end = new Vector2(start.x, start.y - distance);

            //Debug.DrawLine(start, end, Color.blue);
            grounded = Physics2D.Linecast(start, end, groundLayer);
            return (grounded);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        bool isWalking = false;
        bool isJumping = false;


            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                isWalking = true;
                if (playerAni.GetInteger("walking") == 0)
                {
                    playerAni.SetInteger("walking", 1);
                }
                Vector3 theScale = transform.localScale;
                if (theScale.x <= 0)
                {
                    theScale.x *= -1;
                }
                transform.localScale = theScale;
                this.gameObject.transform.position += new Vector3(speed, 0, 0);
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                isWalking = true;
                if (playerAni.GetInteger("walking") == 0)
                {
                    playerAni.SetInteger("walking", 1);
                }


                Vector3 theScale = transform.localScale;
                if (theScale.x >= 0)
                {
                    theScale.x *= -1;
                }
                transform.localScale = theScale;


                this.gameObject.transform.position -= new Vector3(speed, 0, 0);

            }
            else
            {
                playerAni.SetInteger("walking", 0);
            }

            // jump
            if (IsGround && JumpKey)
            {
                playerAni.SetInteger("jump", 1);
                rigid.AddForce(new Vector2(0, 40), ForceMode2D.Impulse);
            }
            else
            {
                playerAni.SetInteger("jump", 0);
            }

        

        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "rope")
        {
            if (isClimbing == false)
            {
                gameObject.GetComponent<Rigidbody2D>().position = new Vector3(gameObject.GetComponent<Rigidbody2D>().position.x-0.1f, gameObject.GetComponent<Rigidbody2D>().position.y+1f, 0);
            }
            isClimbing = true;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0, 0);
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "rope")
        {
            isClimbing = false;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 9.8f;
            //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0, 0);

        }
        
    }
}
