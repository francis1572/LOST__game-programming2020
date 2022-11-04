using UnityEngine;
using System.Collections;

public class player_transfer : MonoBehaviour
{
    public bool[] complete_floor = new bool[5];
    public AudioClip transfer_sound;
    private int currentPortNum = -1;
    private int prevPortNum = -1;
    private int currentPlaceNum = 0;
    private int prevPlaceNum = 0;
    private bool protect_transfer;
    private Vector3 before_enter_position;
    private GameObject bossBgm;
    private GameObject floorBgm;

    // Use this for initialization
    void Start()
    {
        protect_transfer = false;
        for (int i = 0; i < 5; i++)
        {
            complete_floor[i] = false;
        }
        bossBgm = GameObject.Find("bossbgm");
        floorBgm = GameObject.Find("floorbgm");
    }

    // Update is called once per frame
    void Update()
    {
        // different floor portal
        if (currentPortNum != prevPortNum && !protect_transfer)
        {
            GameObject target = GameObject.Find(currentPortNum.ToString() + "F_start");
            if (target != null)
            {
                if (currentPortNum == 0)
                {
                    transfer(0.6f, 0.6f, -190.8f, 286.1f, -260.4f, 241.8f);
                    StartCoroutine(transferEffect(0));
                    if (complete_floor[prevPortNum - 1] == true)
                    {
                        Destroy(GameObject.Find("b_portal" + prevPortNum.ToString()).GetComponent<portIdentify>());
                    }
                    transform.position = new Vector3(before_enter_position.x, before_enter_position.y, before_enter_position.z);
                }
                else
                {
                    before_enter_position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    StartCoroutine(transferEffect(1));
                    if (currentPortNum == 1)
                    {
                        transfer(0.3f, 0.3f, 25.1f, 67.1f, 25.1f, 14.8f);
                    }
                    else if (currentPortNum == 2)
                    {
                        transfer(0.3f, 0.3f, 118.7f, 200.5f, 26.2f, 160.2f);
                    }
                    else if (currentPortNum == 3)
                    {
                        transfer(0.3f, 0.3f, 27f, 406.1f, 27f, 288.9f);
                    }
                    else if (currentPortNum == 4)
                    {
                        transfer(0.3f, 0.3f, 28f, 604.2f, 28f, 507.4f);
                    }
                    else if (currentPortNum == 5)
                    {
                        transfer(0.3f, 0.3f, 29.5f, 836.5f, 29.5f, 719.5f);
                    }
                    
                    transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -1);
                }

                prevPortNum = currentPortNum;
            }
        }

        // same floor portal
        if (currentPlaceNum != prevPlaceNum && !protect_transfer)
        {
            GameObject target = GameObject.Find(currentPlaceNum.ToString());
            if (target != null)
            {
                GetComponent<AudioSource>().PlayOneShot(transfer_sound, 0.7f);
                transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -1);
                prevPlaceNum = currentPlaceNum;
            }
        }
    }

    private void transfer(float scaleX, float scaleY, float cameraMaxX, float cameraMaxY, float cameraMinX, float cameraMinY)
    {
        transform.localScale = new Vector3(scaleX, scaleY, 1);
        Camera.main.GetComponent<CameraFollow>().maxXAndY = new Vector2(cameraMaxX, cameraMaxY);
        Camera.main.GetComponent<CameraFollow>().minXAndY = new Vector2(cameraMinX, cameraMinY);
    }

    private void OnTriggerStay2D(Collider2D triggerCollision)
    {
        if ((triggerCollision.gameObject.tag == "portal" || triggerCollision.gameObject.tag == "boss_portal") && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)))
        {
            if (triggerCollision.gameObject.name.Substring(triggerCollision.gameObject.name.Length - 1) == "0")
            {
                int tar = triggerCollision.gameObject.name[triggerCollision.gameObject.name.Length - 3] - '0';
                complete_floor[tar - 1] = true;
            }
            portIdentify tarFloor = triggerCollision.gameObject.GetComponent<portIdentify>();
            int portal_target_num = tarFloor.targetFloor;
            currentPortNum = portal_target_num;
            protect_transfer = true;
            StartCoroutine(protectTransfer());
        }
        else if (triggerCollision.gameObject.tag == "within_scene_portal" && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && !protect_transfer)
        {
            sameScenePortIdentify tarPlace = triggerCollision.gameObject.GetComponent<sameScenePortIdentify>();
            int target_num = tarPlace.targetPlaceIndex;
            currentPlaceNum = target_num;
            protect_transfer = true;
            StartCoroutine(protectTransfer());
        }
    }

    IEnumerator transferEffect(int port)
    {
        if (port == 0)
        {
            floorBgm.GetComponent<AudioSource>().Stop();
            bossBgm.GetComponent<AudioSource>().Play();
        }
        else
        {
            bossBgm.GetComponent<AudioSource>().Stop();
            floorBgm.GetComponent<AudioSource>().Play();
        }
        GetComponent<AudioSource>().PlayOneShot(transfer_sound, 0.7f);
        yield return new WaitForSeconds(0.7f);
    }

    IEnumerator protectTransfer()
    {
        yield return new WaitForSeconds(0.5f);
        protect_transfer = false;
    }
}
