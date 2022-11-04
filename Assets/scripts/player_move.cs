using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class player_move : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float speed;
    public Animator playerAni;
    public SpriteRenderer player_tri;
    public SpriteRenderer player_pencil;
    public SpriteRenderer playerSr;
    public Transform groundCheck;
    public float distance;
    public LayerMask groundLayer;
    public bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        
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

            Debug.DrawLine(start, end, Color.blue);
            grounded = Physics2D.Linecast(start, end, groundLayer);
            return (grounded);
        }
    }
    // Update is called once per frame
    void Update()
    {
        bool isWalking = false;
        bool isJumping = false;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            isWalking = true;
            if (playerAni.GetInteger("walking") == 0)
            {
                playerAni.SetInteger("walking", 1);
            }
            //playerSr.flipX = false;
            //this.gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0f);

            Vector3 theScale = transform.localScale;
            if (theScale.x <= 0)
            {
                theScale.x *= -1;
            }
            transform.localScale = theScale;

            //player_tri.flipX = false;
            //player_pencil.flipX = false;
            //rigid.AddForce(new Vector2(10, 0), ForceMode2D.Force);
            //Debug.Log(transform.position);
            this.gameObject.transform.position += new Vector3(speed, 0, 0);
            
            //Debug.Log(speed);
            //Debug.Log(transform.position);
            //playerAni.SetInteger("walking", 0);
        }
        else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            isWalking = true;
            if (playerAni.GetInteger("walking") == 0)
            {
                playerAni.SetInteger("walking", 1);
            }
            //playerSr.flipX = true;
            //this.gameObject.transform.localScale = new Vector3(-0.3f, 0.3f, 0f);

            Vector3 theScale = transform.localScale;
            if (theScale.x >= 0)
            {
                theScale.x *= -1;
            }
            transform.localScale = theScale;

            //player_tri.flipX = true;
            //player_pencil.flipX = true;
            //rigid.AddForce(new Vector2(-10, 0), ForceMode2D.Force);
            this.gameObject.transform.position -= new Vector3(speed, 0, 0);
            //playerAni.SetInteger("walking", 0);
        }
        else
        {
            playerAni.SetInteger("walking", 0);
        }

        // jump
        if (IsGround && JumpKey)
        {
            playerAni.SetInteger("jump", 1);
            // rigid.AddForce(new Vector2(0, 25), ForceMode2D.Impulse);
            rigid.AddForce(new Vector2(0, 50), ForceMode2D.Impulse);
        }
        else
        {
            playerAni.SetInteger("jump", 0);
        }

        
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "movingstep" && IsGround)
        {
            StepMoving step = other.gameObject.GetComponent<StepMoving>();
            float step_speed = step.speed;
            float step_LR = step.LR;
            transform.position += new Vector3(step_speed * step_LR * Time.deltaTime, 0, 0);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "movingstep" && IsGround)
        {
            transform.position += new Vector3(0, 0, 0);
        }
    }
}
