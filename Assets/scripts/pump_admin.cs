using UnityEngine;
using System.Collections;
using System.Linq;

public class pump_admin : MonoBehaviour
{
    public ArrayList bag_list = new ArrayList();
    private ArrayList copy = new ArrayList();
    private ArrayList pump_list = new ArrayList();
    // Use this for initialization
    void Start()
    {
        foreach(Transform child in transform)
        {
            pump_list.Add(int.Parse(child.name));
            copy.Add(int.Parse(child.name));
        }
        //copy = pump_list;
        //Debug.Log(pump_list.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("wagon").GetComponent<pump_to_wagon>().trigger)
        {
            bag_list = new ArrayList();
        }
        else
        {
            pump_list = new ArrayList();
            foreach (Transform child in transform)
            {
                pump_list.Add(int.Parse(child.name));
            }
            foreach (int i in copy)
            {
                if (!pump_list.Contains(i))
                {
                    if (!bag_list.Contains(i))
                    {
                        bag_list.Add(i);
                    }

                    //Debug.Log(i);
                }
            }
        }
        
        //Debug.Log(bag_list.Count);
        //Debug.Log(pump_list.Count);
        //Debug.Log(copy.Count);
    }
}
