using UnityEngine;
using System.Collections;

public class player_enter_book : MonoBehaviour
{
    public GameObject[] books;
    public GameObject[] books_ani;

    // Use this for initialization
    void Start()
    {
        foreach (GameObject book in books_ani)
        {
            book.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "book")
        {
            string tar_name = collision.gameObject.name;
            int tar_index = 0;
            if (tar_name.Contains("Fake"))
            {
                int f_index = tar_name.IndexOf("Fake");
                tar_index = int.Parse(tar_name.Substring(f_index + 4));
            }
            else
            {
                tar_index = tar_name[tar_name.Length - 1] - '0';
            }
            books[tar_index].SetActive(false);
            books_ani[tar_index].SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D exit_collision)
    {
        if (exit_collision.gameObject.tag == "book")
        {
            string tar_name = exit_collision.gameObject.name;
            int tar_index = 0;
            if (tar_name.Contains("Fake"))
            {
                int f_index = tar_name.IndexOf("Fake");
                tar_index = int.Parse(tar_name.Substring(f_index + 4));
            }
            else
            {
                tar_index = tar_name[tar_name.Length - 1] - '0';
            }
            books[tar_index].SetActive(true);
            books_ani[tar_index].SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D stay_collision)
    {
        if (stay_collision.gameObject.tag == "book")
        {
            if (Input.GetKey(KeyCode.UpArrow) && !stay_collision.gameObject.name.Contains("Fake"))
            {
                // load scene here
            }
        }
    }
}
