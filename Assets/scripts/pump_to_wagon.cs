using UnityEngine;
using System.Collections;
using Fungus;

public class pump_to_wagon : MonoBehaviour
{

    private int cnt;
    public Animator wagon_moving;
    public GameObject pumpkins;
    private GameObject pumps;
    public bool trigger;

    // Use this for initialization
    void Start()
    {
        cnt = 0;
        trigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        ArrayList bag_list = GameObject.Find("pumpkins(Clone)").GetComponent<pump_admin>().bag_list;
        //Debug.Log(bag_list.Count);
        if (bag_list.Count > 0)
        {
            cnt = 0;
            foreach (int i in bag_list)
            {
                if (i == 1)
                {
                    cnt += 1;
                }
                else if (i == 5)
                {
                    cnt += 1;
                }
                else if (i == 6)
                {
                    cnt += 1;
                }
                else if (i == 7)
                {
                    cnt += 1;
                }
                else if (i == 9)
                {
                    cnt += 1;
                }
                else if (i == 10)
                {
                    cnt += 1;
                }
                else if (i == 12)
                {
                    cnt += 1;
                }
                else if (i == 13)
                {
                    cnt += 1;
                }
                else if (i == 14)
                {
                    cnt += 1;
                }
                else if (i == 16)
                {
                    cnt += 1;
                }
                else if (i == 17)
                {
                    cnt += 1;
                }
                else if (i == 21)
                {
                    cnt += 1;
                }
                else if (i == 22)
                {
                    cnt += 1;
                }
                else
                {
                    cnt -= 1;
                }
            }
            //Debug.Log(cnt);
            if (cnt == 13)
            {
                wagon_go();        
            }
            else
            {
                trigger = true;
                wagon_not_ok();
                
            }
        }
    }
    private void wagon_go()
    {
        Flowchart.BroadcastFungusMessage("start to move");
        cnt += 1;
    }
    private void wagon_not_ok()
    {
        cnt = 0;
        Destroy(GameObject.Find("pumpkins(Clone)"));
        pumps = Instantiate(pumpkins, new Vector3(0.7989304f, 3.932205f, -3.66637f), new Quaternion(0, 0, 0, 0));
        //pumpkins1 = new GameObject(pumpkins2);
        Flowchart.BroadcastFungusMessage("reverse");
        trigger = false;
    }
    private void reset()
    {
        Destroy(GameObject.Find("pumpkins(Clone)"));
        pumps = Instantiate(pumpkins, new Vector3(0.7989304f, 3.932205f, -3.66637f), new Quaternion(0, 0, 0, 0));
    }
}
