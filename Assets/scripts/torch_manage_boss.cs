using UnityEngine;
using System.Collections;

public class torch_manage_boss : MonoBehaviour
{
    private GameObject player;
    private bool[] already_trigger;
    private bool[] prev_trigger;
    public GameObject[] fires;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("player");
        fires = GameObject.FindGameObjectsWithTag("torch_fire");
        foreach (GameObject f in fires)
        {
            //Debug.Log(f.name);
            f.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        already_trigger = player.GetComponent<player_fire>().already_fired;
        if (already_trigger != prev_trigger)
        {
            for (int i = 0; i < 4; i++)
            {
                if (already_trigger[i] == true)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        int ind = fires[k].name[fires[k].name.Length - 1] - '0';
                        if (ind == (i + 1))
                        {
                            fires[k].SetActive(true);
                        }
                    }
                }
            }
        }
    }
}
