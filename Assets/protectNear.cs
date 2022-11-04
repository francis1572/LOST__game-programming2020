using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class protectNear : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {

            StartCoroutine(wait_seconds());
            //Debug.Log("hhh");
        }
    }
    private IEnumerator wait_seconds()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 0.2f);
        Vector3 player_postion = GameObject.Find("player").transform.position;
        GameObject.Find("player").transform.position = Vector3.Lerp(player_postion, new Vector3(player_postion.x - 10, player_postion.y, 0), 0.8f);
        yield return new WaitForSeconds(1f);
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 0.1f);

    }
}

