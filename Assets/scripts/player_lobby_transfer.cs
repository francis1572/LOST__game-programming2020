using UnityEngine;
using System.Collections;
using Fungus;

public class player_lobby_transfer : MonoBehaviour
{
    public int currentPlaceNum = 0;
    private int prevPlaceNum = 0;
    private bool protect_transfer;
    private Vector3 before_enter_position;
    private bool crazyMusic = false;
    public static Flowchart talkFlowchart;
    public AudioClip transferSound;
    GameObject bgmPoint;
    GameObject prevBgmPoint;

    // Use this for initialization
    void Start()
    {
        protect_transfer = false;
        prevBgmPoint = GameObject.Find("LobbyBgm");
        talkFlowchart = GameObject.FindGameObjectWithTag("talkFlowchart").GetComponent<Flowchart>();

        string prevComingPlace = CrossSceneClass.PreviousSceneName;
        if (prevComingPlace == "history_book1" || prevComingPlace == "history_book2")
        {
            currentPlaceNum = 2; // back from history book
        }
        else if (prevComingPlace == "jack_final")
        {
            currentPlaceNum = 6; // back from jack
        }
        else if (prevComingPlace == "firstbook_black")
        {
            currentPlaceNum = 4; // back from little red
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fungusMusic && !crazyMusic)
        {
            GameObject.Find("LobbyBgm").GetComponent<AudioSource>().Stop();
            GameObject.Find("UniverseBgm").GetComponent<AudioSource>().Stop();
            crazyMusic = true;
        }
        //Debug.Log(fungusMusic);
        //Debug.Log(crazyMusic);
        if (fungusMusic == false && crazyMusic == true)
        {
            //Debug.Log("keke") ;
            crazyMusic = false;
            GameObject.Find("LobbyBgm").GetComponent<AudioSource>().Play();
        }
        // same scene portal
        if (currentPlaceNum != prevPlaceNum && !protect_transfer)
        {
            GameObject target = GameObject.Find(currentPlaceNum.ToString());
            if (target != null)
            {
                if (currentPlaceNum == 9 || currentPlaceNum == 10 || currentPlaceNum == 11 || currentPlaceNum == 12 || currentPlaceNum == 13)
                {
                    GetComponent<AudioSource>().PlayOneShot(transferSound, 0.7f);
                    transform.position = new Vector3(target.transform.position.x, target.transform.position.y, 0);
                    prevPlaceNum = currentPlaceNum;
                }
                else
                {
                    if (currentPlaceNum == 2)
                    {
                        transfer(-154.9f, 111.6f, -167.1f, 107.1f);
                        bgmPoint = GameObject.Find("UniverseBgm");
                    }
                    else if (currentPlaceNum == 4)
                    {
                        transfer(-160.7f, -62.2f, -179.2f, -69.8f);
                        bgmPoint = GameObject.Find("JapanBgm");
                    }
                    else if (currentPlaceNum == 6)
                    {
                        transfer(280.4f, 125.9f, 266.7f, 121.1f);
                        bgmPoint = GameObject.Find("GhostBgm");
                    }
                    else if (currentPlaceNum == 8)
                    {
                        transfer(290.3f, -60.3f, 267.6f, -67.9f);
                        bgmPoint = GameObject.Find("FairyTaleBgm");
                    }
                    else
                    {
                        transfer(44.5f, 5.9f, 43.7f, -7.1f);
                        bgmPoint = GameObject.Find("LobbyBgm");
                    }

                    if (prevBgmPoint != null)
                    {
                        prevBgmPoint.GetComponent<AudioSource>().Stop();
                    }

                    GetComponent<AudioSource>().PlayOneShot(transferSound, 0.7f);
                    bgmPoint.GetComponent<AudioSource>().Play();
                    prevBgmPoint = bgmPoint;
                    transform.position = new Vector3(target.transform.position.x, target.transform.position.y, 0);
                    prevPlaceNum = currentPlaceNum;
                }
            }
        }
    }

    private void transfer(float cameraMaxX, float cameraMaxY, float cameraMinX, float cameraMinY)
    {
        Camera.main.GetComponent<CameraFollow>().maxXAndY = new Vector2(cameraMaxX, cameraMaxY);
        Camera.main.GetComponent<CameraFollow>().minXAndY = new Vector2(cameraMinX, cameraMinY);
    }

    private void OnTriggerStay2D(Collider2D triggerCollision)
    {
        if (triggerCollision.gameObject.tag == "within_scene_portal" && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && !protect_transfer)
        {
            sameScenePortIdentify tarPlace = triggerCollision.gameObject.GetComponent<sameScenePortIdentify>();
            int target_num = tarPlace.targetPlaceIndex;
            currentPlaceNum = target_num;
            protect_transfer = true;
            StartCoroutine(protectTransfer());
        }
    }

    IEnumerator protectTransfer()
    {
        yield return new WaitForSeconds(0.5f);
        protect_transfer = false;
    }

    public static bool fungusMusic
    {
        get { return talkFlowchart.GetBooleanVariable("fgMusic"); }
    }
}
