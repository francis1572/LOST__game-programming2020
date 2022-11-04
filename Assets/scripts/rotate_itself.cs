using UnityEngine;
using System.Collections;

public class rotate_itself : MonoBehaviour
{
    private bool trigger_on;
    private bool prev_trigger;
    public float rotate_x;
    public float rotate_y;
    public float rotate_z;
    public GameObject target;
    public string scriptName;

    // Use this for initialization
    void Start()
    {
        trigger_on = false;
        prev_trigger = false;
        scriptName = "";
    }

    // Update is called once per frame
    void Update()
    {
        trigger_on = target.GetComponent<trigger_items>().is_bookshelf_trigger;
        if (trigger_on)
        {
            prev_trigger = true;
            transform.parent.gameObject.transform.RotateAround(transform.position, new Vector3(rotate_x, rotate_y, rotate_z), Time.deltaTime * 90);
        }
        else
        {
            if (prev_trigger)
            {
                StartCoroutine("destroy");
            }
        }
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
