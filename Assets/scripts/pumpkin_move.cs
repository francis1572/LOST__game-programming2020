using UnityEngine;
using System.Collections;

public class pumpkin_move : MonoBehaviour
{
    private GameObject bag;

    // Use this for initialization
    void Start()
    {
        bag = GameObject.Find("pumpkin_bag");
    }

    // Update is called once per frame

    void OnMouseDown()
    {
        Destroy(gameObject);
        GameObject.Find("moveSound").GetComponent<AudioSource>().Play();
    }
}
