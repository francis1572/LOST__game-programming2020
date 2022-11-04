using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchBack : MonoBehaviour
{
    // Start is called before the first frame update
    public float x_pos;
    public float y_pos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void return_place()
    {
        this.gameObject.transform.SetParent(null);
        this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        this.gameObject.transform.rotation = new Quaternion(0, 0, 0, 1);
        this.gameObject.transform.position = new Vector3(x_pos, y_pos, 0);
        this.gameObject.GetComponent<Fungus.Draggable2D>().enabled = false;
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 18;
    }
}
