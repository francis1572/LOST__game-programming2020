using UnityEngine;
using System.Collections;

public class jack_final : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void switch_1()
    {
        gameObject.GetComponent<SpriteRenderer>().flipX = true;
    }
    private void switch_2()
    {
        gameObject.GetComponent<SpriteRenderer>().flipX = false;
    }
}
