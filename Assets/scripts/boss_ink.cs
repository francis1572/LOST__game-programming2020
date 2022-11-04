using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_ink : MonoBehaviour
{
    public float Time;
    public GameObject ink;
    public GameObject firpoint;
    // Start is called before the first frame update
    void Start()
    {
        firpoint = GameObject.Find("BossPenInstPoint");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("haha");
        if (collision.gameObject.tag == "floor")
        {
            //Debug.Log(firpoint.GetComponent<boss_drawback>().inks.Count);

            GameObject tempInk = Instantiate(ink, transform.position, transform.rotation);
            firpoint.GetComponent<boss_drawback>().inks.Add(tempInk);

            Destroy(gameObject, Time);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("haha");
        if (collision.gameObject.tag == "floor")
        {
            //Debug.Log(firpoint.GetComponent<boss_drawback>().inks.Count);

            GameObject tempInk = Instantiate(ink, transform.position, transform.rotation);
            firpoint.GetComponent<boss_drawback>().inks.Add(tempInk);

            Destroy(gameObject, Time);

        }
    }
}
