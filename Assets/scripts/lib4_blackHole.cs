using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

public class lib4_blackHole : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject final_charge;
    public GameObject toLeaveCollider;
    public static Flowchart talkFlowchart;
    public bool isActive = true;
    void Start()
    {
        talkFlowchart = GameObject.FindGameObjectWithTag("talkFlowchart").GetComponent<Flowchart>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activateBlackHole && isActive)
        {
            isActive = false;
            StartCoroutine(blackHoleGen());
        }

        //if (toLeave)
        //{
        //    toLeaveCollider.SetActive(true);
        //}
    }
    public static bool activateBlackHole
    {
        get { return talkFlowchart.GetBooleanVariable("history_read"); }
    }

    public static bool toLeave
    {
        get { return talkFlowchart.GetBooleanVariable("history_higan"); }
    }
    IEnumerator blackHoleGen()
    {
        while(true)
        {
            GameObject charge_clone = Instantiate(final_charge, new Vector3(-188.73f, 90.88f, 1f), new Quaternion(0, 0, 0, 0));
            yield return new WaitForSeconds(2f);
            Destroy(charge_clone, 0);
        }


        //即死全圖炸


        yield return null;
    }
}
