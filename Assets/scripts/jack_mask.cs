using UnityEngine;
using System.Collections;

public class jack_mask : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void turn_dark()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
    }
    private void reverse()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
    }
    private void turn_bright()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
}
