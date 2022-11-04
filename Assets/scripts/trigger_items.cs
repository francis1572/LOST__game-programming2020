using UnityEngine;
using System.Collections;

public class trigger_items : MonoBehaviour
{
    private GameObject corner;
    public bool is_bookshelf_trigger;
    public bool is_fallbooks_trigger;
    private bool only_one_time;
    private float width;
    private float height;
    private Vector3 center;
    private Vector3 point;
    private Vector3 axis;

    // Use this for initialization
    void Start()
    {
        is_bookshelf_trigger = false;
        is_fallbooks_trigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "TriggerBookshelfLine_1F")
        {
            is_bookshelf_trigger = true;
            StartCoroutine(stop("is_bookshelf_trigger"));
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name == "TriggerBookFallLine_1F")
        {
            is_fallbooks_trigger = true;
            StartCoroutine(stop("is_fallbooks_trigger"));
            Destroy(collision.gameObject);
        }
    }

    IEnumerator stop(string param)
    {
        yield return new WaitForSeconds(0.95f);
        if (param == "is_bookshelf_trigger")
        {
            is_bookshelf_trigger = false;
        }
        else if (param == "is_fallbooks_trigger")
        {
            is_fallbooks_trigger = false;
        }
    }
}
