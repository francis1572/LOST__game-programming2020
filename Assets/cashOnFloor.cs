using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cashOnFloor : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isDrop;
    public Vector3 dropPosition;
    public List<GameObject> cash_list;

    void Start()
    {
        isDrop = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.transform.tag);
        if(collision.transform.tag == "cash")
        {
            cash_list.Add(collision.gameObject);
            isDrop = true;
            dropPosition = collision.transform.position + new Vector3(3, 2, 0);
            GameObject.Find("moneyDropSound").GetComponent<AudioSource>().Play();
        }
    }
}
