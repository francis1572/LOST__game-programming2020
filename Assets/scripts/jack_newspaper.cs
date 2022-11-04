using UnityEngine;
using System.Collections;

public class jack_newspaper : MonoBehaviour
{
    private GameObject newspaper;
    private bool flag;
    // Use this for initialization
    void Start()
    {
        newspaper = GameObject.Find("newspaper");
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            transfer_cam();
        }
        else
        {
            if (flag)
            {
                Camera.main.transform.position = new Vector3(-0.14f, -15.05f, -10);
            }
            else
            {
                Camera.main.transform.position = new Vector3(-0.71f, 0.24f, -10);
            }
            
        }
    }

    private void switch_order()
    {
        transform.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 10;

        foreach(Transform news in newspaper.transform)
        {
            news.transform.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 11;
        }
        
    }

    private void trans_news()
    {
        newspaper.gameObject.transform.position = new Vector3(3.56f, -1.54f, 1);
    }
    private void transfer_cam()
    {
        Camera.main.transform.position = new Vector3(-22.6f, -13.86f, -10);
    }
    private void switch_cam()
    {
        flag = true;
        Camera.main.transform.position = new Vector3(-0.14f, -15.05f, -10);
    }
    private void room_cam()
    {
        flag = false;
    }
}
