using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMoney : MonoBehaviour
{
    public Fungus.Flowchart story_flowchart;
    public float max_dist;
    public List<GameObject> all_cash;
    private GameObject cash;
    public AudioClip pickUpSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        check_close();
    }
    private void check_close()
    {
        for(int i =0; i< all_cash.Count; i++)
        {
            if (all_cash[i] == null)
                continue;
            float dist = Vector3.Distance(all_cash[i].transform.position, this.gameObject.transform.position);
            if (dist < max_dist)
            {
                story_flowchart.SetBooleanVariable("closeToMoney_"+i.ToString(), true);
            }
            else
            {
               
                story_flowchart.SetBooleanVariable("closeToMoney_" + i.ToString(), false);
            }
        }
        
    }
    public void setCashParent()
    {
        
        for (int i = 0; i < all_cash.Count; i++)
        {
            
            if (story_flowchart.GetBooleanVariable("closeToMoney_" + i.ToString()) == true)
            {
                cash = all_cash[i];
            }
        }
        GetComponent<AudioSource>().PlayOneShot(pickUpSound);
        cash.transform.SetParent(this.gameObject.transform);
        cash.transform.position = this.gameObject.transform.position + new Vector3(-0.5f, 2, 0);
    }
    public void removeCashParent()
    {
        foreach(Transform child in this.gameObject.transform)
        {
            if (child.tag == "cash")
                cash = child.gameObject;
        }
        cash.transform.position = this.gameObject.transform.position + new Vector3(1.5f, 0, 0);
        cash.transform.parent = null;
        //cash.AddComponent<Rigidbody2D>();
    }

}
