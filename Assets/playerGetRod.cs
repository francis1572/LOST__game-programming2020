using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGetRod : MonoBehaviour
{
    // Start is called before the first frame update
    public Fungus.Flowchart story_flowchart;
    public fishing rod_fishing;
    public AudioClip pickSound;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.name == "rod")
        {
            GameObject rod = GameObject.Find("rod");
            rod.transform.SetParent(this.gameObject.transform);
            float x_dir = get_sign(this.gameObject.transform.localScale.x);
            //Debug.Log(x_dir);
            GetComponent<AudioSource>().PlayOneShot(pickSound);
            rod.transform.rotation = new Quaternion(0, Mathf.Max(0, 1 * x_dir), 0, 0);
            rod.transform.position = this.gameObject.transform.position + new Vector3(4.5f* x_dir, 1f, 0);
            story_flowchart.SetBooleanVariable("take_rod", true);
            //rod.transform.localScale = new Vector3(0.8f, 0.8f, 0);
        }
    }
    public void start_fishing()
    {
        rod_fishing.enabled = true;
        GameObject.Find("fishingSound").GetComponent<AudioSource>().Play();
    }
    public void end_fishing()
    {
        rod_fishing.enabled = false;
        GameObject.Find("fishingSound").GetComponent<AudioSource>().Stop();
    }
    public void find_hook()
    {
        GameObject hook = GameObject.Find("hook");
        GameObject rod = GameObject.Find("rod");
        hook.transform.SetParent(rod.transform);
        float x_dir = get_sign(this.gameObject.transform.localScale.x);
        hook.transform.position = rod.transform.position + new Vector3(-1* x_dir, -3, 0);
    }
    public float get_sign(float number)
    {
        if(number > 0)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

}
