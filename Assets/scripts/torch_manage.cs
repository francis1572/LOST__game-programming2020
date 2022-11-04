using UnityEngine;
using System.Collections;
using Fungus;
public class torch_manage : MonoBehaviour
{
    private GameObject player;
    private int trigger_fire_num;
    private bool[] already_trigger = new bool[5];
    private bool[] prev_trigger = new bool[5];
    public GameObject[] fires;
    public static Flowchart talkFlowchart;
    private bool change;
    private bool isWin = true;

    private GameObject fire1;
    private GameObject fire2;
    private GameObject fire3;
    private GameObject fire4;
    private GameObject fire5;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("player");
        talkFlowchart = GameObject.FindGameObjectWithTag("talkFlowchart").GetComponent<Flowchart>();

        fire1 = GameObject.Find("torch_fire1");
        fire2 = GameObject.Find("torch_fire2");
        fire3 = GameObject.Find("torch_fire3");
        fire4 = GameObject.Find("torch_fire4");
        fire5 = GameObject.Find("torch_fire5");

        fire1.SetActive(false);
        fire2.SetActive(false);
        fire3.SetActive(false);
        fire4.SetActive(false);
        fire5.SetActive(false);

        for (int i = 0; i < 5; i++)
        {
            prev_trigger[i] = false;
        }

        trigger_fire_num = 0;
        change = false;
    }

    // Update is called once per frame
    void Update()
    {
        already_trigger = player.GetComponent<player_transfer>().complete_floor;
        trigger_fire_num = 0;
        for (int i = 0; i < 5; i++)
        {
            if (already_trigger[i] == true)
            {
                trigger_fire_num += 1;
                StartCoroutine(wait());
                switch (i)
                {
                    case 0:
                        fire1.SetActive(true);
                        break;
                    case 1:
                        fire2.SetActive(true);
                        break;
                    case 2:
                        fire3.SetActive(true);
                        break;
                    case 3:
                        fire4.SetActive(true);
                        break;
                    case 4:
                        fire5.SetActive(true);
                        break;
                    default:
                        break;
                }
            }
        }

        if (trigger_fire_num == 5 && isWin)
        {
            // success and go to final battle scene
            talkFlowchart.ExecuteBlock("win");
            player.GetComponent<player_move>().enabled = false;
            isWin = false;

        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.2f);
    }
}
