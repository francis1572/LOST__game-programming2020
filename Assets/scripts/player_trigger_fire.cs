using UnityEngine;
using System.Linq;
using System.Collections;

public class player_trigger_fire : MonoBehaviour
{
    public bool ifSuccess;
    public bool[] triggered = new bool[5];
    public GameObject[] fires;

    // Use this for initialization
    void Start()
    {
        ifSuccess = false;
        fires = GameObject.FindGameObjectsWithTag("torch_fire");
        foreach (GameObject f in fires)
        {
            f.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        // trigger torch fire
        //if (collider.gameObject.tag == "torch")
        //{
        //    if (Input.GetKey(KeyCode.F))
        //    {
        //        GameObject target = collider.gameObject;
        //        char fireIndex = target.name[target.name.Length-1];
        //        int order = fireIndex - '0';
        //        if (!trigger_order.Contains(order))
        //        {
        //            trigger_order[trigger_index] = order;
        //            fires[order-1].SetActive(true);

        //            if (trigger_index == 5)
        //            {
        //                bool isEqual = Enumerable.SequenceEqual(trigger_order, correct_ans);
        //                if (isEqual) // success, tirgger portal
        //                {
        //                    ifSuccess = true;
        //                }
        //                else // fail
        //                {
        //                    StartCoroutine(initial());
        //                }
        //            }
        //        }
        //    }
        //}
    }

    private IEnumerator initial()
    {
        yield return new WaitForSeconds(0.2f);
        triggered = new bool[5];
    }
}
