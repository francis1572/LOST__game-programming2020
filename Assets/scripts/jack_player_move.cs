using UnityEngine;
using System.Collections;

public class jack_player_move : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void move_disable()
    {
        gameObject.GetComponent<player_move>().enabled = false;
    }

    private void move_enable()
    {
        gameObject.GetComponent<player_move>().enabled = true;
    }

    public void resetBox()
    {
        GameObject.Find("wood_box").transform.position = new Vector3(7.22f, 2.84f, 0f);
        GameObject.Find("wood_box").transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        GameObject.Find("wood_box (1)").transform.position = new Vector3(-4.7f, 55.1f, 0f);
        GameObject.Find("wood_box (1)").transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        GameObject.Find("wood_box (2)").transform.position = new Vector3(6.34f, 18.82f, 0f);
        GameObject.Find("wood_box (2)").transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        GameObject.Find("wood_box (3)").transform.position = new Vector3(-13.18f, 11.9f, 0f);
        GameObject.Find("wood_box (3)").transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        GameObject.Find("wood_box (4)").transform.position = new Vector3(6.9f, 42f, 0f);
        GameObject.Find("wood_box (4)").transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        GameObject.Find("wood_box (5)").transform.position = new Vector3(9.6f, 52f, 0f);
        GameObject.Find("wood_box (5)").transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        GameObject.Find("wood_box (6)").transform.position = new Vector3(-13.65f, 2.82f, 0f);
        GameObject.Find("wood_box (6)").transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
