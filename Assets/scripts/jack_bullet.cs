using UnityEngine;
using System.Collections;

public class jack_bullet : MonoBehaviour
{
    private GameObject mask;
    private GameObject bullet;
    private GameObject dead;
    private float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    private GameObject player;
    private GameObject pumpkin;

    // Use this for initialization
    void Start()
    {
        mask = GameObject.Find("Mask");
        bullet = GameObject.Find("bullet");
        dead = GameObject.Find("dead_boy");
        player = GameObject.Find("player");
        pumpkin = GameObject.Find("pumpkin");

        player.gameObject.GetComponent<player_move>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void get_hit()
    {
        mask.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
        Destroy(bullet.gameObject);
        dead.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 10;
        transform.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;        
    }

    private void hit_reverse()
    {        
        mask.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
    }

    private void pumpkin_start()
    {
        player.gameObject.GetComponent<player_move>().enabled = true;
        mask.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
        pumpkin.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3f, 0);
        pumpkin.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 10;
        pumpkin.transform.SetParent(player.transform);
    }
}
