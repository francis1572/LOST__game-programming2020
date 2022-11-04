using UnityEngine;
using System.Collections;

public class player_fire : MonoBehaviour
{
    public bool all_fired;
    public bool[] already_fired = new bool [4];

    // Use this for initialization
    void Start()
    {
        all_fired = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (all_fired == false)
            all_fired = already_fired[0] && already_fired[1] && already_fired[2] && already_fired[3];
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "torch")
        {
            if (Input.GetKey(KeyCode.F))
            {
                int tar = collision.gameObject.name[collision.gameObject.name.Length - 1] - '0';
                //Debug.Log(tar);
                already_fired[tar - 1] = true;
            }
        }
    }
}
