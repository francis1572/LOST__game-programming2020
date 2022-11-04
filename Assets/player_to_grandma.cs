using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_to_grandma : MonoBehaviour
{
    public player_move_in_book_one player_Move_In_Book_One;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //move_to_road(new Vector3(-8, -6, 0));
    }
    public void move_to_grandma()
    {
        move_to_road(new Vector3(-6, -6, 0));
        disappear();
        move_to_road(new Vector3(5.5f, -1, 0));
        shown();
        move_to_road(new Vector3(15, -2, 0));
    }
    private void move_to_road(Vector3 target_direction)
    {
        player_Move_In_Book_One.enabled = false;
        this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, target_direction, 2);
    }
    private IEnumerator disappear()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -10;
        yield return new WaitForSeconds(0f);
    }
    private void shown()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 10;
    }
}
