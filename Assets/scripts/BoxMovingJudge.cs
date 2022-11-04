using UnityEngine;
using System.Collections;

public class BoxMovingJudge : MonoBehaviour
{
    public AudioClip sound;
    private bool flag;
    private Vector3 prevPos;

    // Use this for initialization
    void Start()
    {
        flag = false;
        prevPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!flag)
        //{
        //    if (prevPos.x != transform.position.x)
        //    {
        //        flag = true;
        //        StartCoroutine(protect());
        //    }
        //}
        if (flag)
        {
            prevPos = transform.position;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !flag)
        {
            if (System.Math.Abs(prevPos.x - transform.position.x) > 0.8f && (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
            {
                prevPos = transform.position;
                flag = true;
                StartCoroutine(protect());
            }
            //flag = true;
            //StartCoroutine(protect());
        }
    }

    IEnumerator protect()
    {
        GetComponent<AudioSource>().PlayOneShot(sound);
        yield return new WaitForSeconds(1.5f);
        flag = false;
    }
}
