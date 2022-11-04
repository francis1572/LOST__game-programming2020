using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_hp_controller_v2 : MonoBehaviour
{
    public GameObject controller1;
    public GameObject controller2;
    public GameObject controller3;
    public GameObject activateTorch;

    public GameObject butterflyInst;
    public GameObject chainInst;
    public GameObject UBWInst;
    public GameObject final_charge;
    public GameObject final_blaze;

    public GameObject terrain1;
    public GameObject terrain2;

    //public GameObject laserInst1;
    //public GameObject laserInst2;
    //public GameObject laserInst3;
    //public GameObject laserInst4;

    public float boss_full_hp = 200;
    public bool isActive70 = true;
    public bool isActive60 = true;
    public bool isActive50 = true;
    public bool isActive40 = true;
    public bool isActive30 = true;
    public bool isActive20 = true;
    public bool isActive10 = true;

    public bool battleIsStart = false;
    public Fungus.Flowchart flowchart;
    

    public float finalCountDown = 999;
    public float Boss_Life_Num;
    public GameObject boss;

    public AudioClip chargeSound;
    public AudioClip explodeSound;

    private GameObject player;
    private int chargeCnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        Boss_Life_Num = boss.GetComponent<boss_collision>().Boss_Life_Num;
        bool isAllFired = player.GetComponent<player_fire>().all_fired;
        bool fgs_startBattle = flowchart.GetBooleanVariable("start_battle");
        

        if (fgs_startBattle == true && battleIsStart == false)
        {
            battleIsStart = true;
            GameObject.Find("player").GetComponent<player_move>().enabled = true;
            //Debug.Log("fefefefe");
            controller1.SetActive(true);
        }

        //壓進70%
        if (Boss_Life_Num <= boss_full_hp * 0.7 && isActive70 == true)
        {
            isActive70 = false;

            //啟動第二回圈
            Destroy(controller1, 0);
            controller2.SetActive(true);

            flowchart.ExecuteBlock("70%");
            terrain1.SetActive(false);
            terrain2.SetActive(true);
            StartCoroutine(attack70());
            
        }

        //壓進60%
        if (Boss_Life_Num <= boss_full_hp * 0.6 && isActive60 == true)
        {
            isActive60 = false;
            flowchart.ExecuteBlock("70%down");
            StartCoroutine(attack70());

        }

        //壓進50%
        if (Boss_Life_Num <= boss_full_hp * 0.5 && isActive50 == true)
        {
            isActive50 = false;
            flowchart.ExecuteBlock("70%down");
            StartCoroutine(attack70());

        }

        //壓進40%
        if (Boss_Life_Num <= boss_full_hp * 0.4 && isActive40 == true)
        {
            isActive40 = false;

            //啟動第三回圈
            Destroy(controller2, 0);
            controller3.SetActive(true);

            //啟動重力球
            flowchart.ExecuteBlock("40%");
            terrain2.SetActive(false);
            terrain1.SetActive(true);
            StartCoroutine(attack40());


        }

        //壓進30%
        if (Boss_Life_Num <= boss_full_hp * 0.3 && isActive30 == true)
        {
            isActive30 = false;
            flowchart.ExecuteBlock("40%down");
            StartCoroutine(attack40());

        }

        //壓進20%
        if (Boss_Life_Num <= boss_full_hp * 0.2 && isActive20 == true)
        {
            isActive20 = false;
            flowchart.ExecuteBlock("40%down");
            StartCoroutine(attack40());

        }

        //壓進10%
        if (Boss_Life_Num <= boss_full_hp * 0.1 && isActive10 == true)
        {
            isActive10 = false;
            finalCountDown = 27;
            boss.GetComponent<boss_collision>().enabled = !boss.GetComponent<boss_collision>().enabled;
            flowchart.ExecuteBlock("10%");
            StartCoroutine(attack10());

            //show torch and check whether all fires are lighted
            //activateTorch.SetActive(true);
            //bool isAllFired = player.GetComponent<player_fire>().all_fired;
        }

        if(finalCountDown <= 30 && finalCountDown >= 0)
        {
            finalCountDown -= Time.deltaTime;

        }


        if (finalCountDown <= 0)
        {
            //Debug.Log("你已經使惹");
            Destroy(controller3, 0);
            Destroy(GameObject.Find("BossPenInstPoint"));
            Destroy(GameObject.Find("appleInst(Clone)"));
            //GameObject.Find("BossPenInstPoint");
            GameObject blaze_clone = Instantiate(final_blaze, new Vector3(33.54f, 11.1f, 1f), new Quaternion(0, 0, 0, 0));
            GetComponent<AudioSource>().PlayOneShot(explodeSound);
            GetComponent<boss_hp_controller_v2>().enabled = false;
            

        }

        if (isAllFired == true)
        {
            boss.GetComponent<boss_collision>().enabled = !boss.GetComponent<boss_collision>().enabled;
            GameObject.Find("player").GetComponent<player_collision>().enabled = !GameObject.Find("player").GetComponent<player_collision>().enabled;
            boss.GetComponent<boss_collision>().Boss_Life_Num = 0;
            //Debug.Log("我媽活了");
            Destroy(GameObject.Find("appleInst(Clone)"));
            Destroy(gameObject, 0);
        }

        if (chargeCnt == 12)
        {
            CancelInvoke("chargeSoundEffect");
        }

    }

    IEnumerator attack70()
    {
        yield return new WaitForSeconds(2);
        //蝴蝶彈幕
        butterflyInst.SetActive(true);
        yield return new WaitForSeconds(6);
        butterflyInst.SetActive(false);
        butterflyInst.GetComponent<boss_butterfly_v2>().isActive = false;
        yield return null;
    }

    IEnumerator attack40()
    {
        yield return new WaitForSeconds(2);
        //蝴蝶彈幕
        butterflyInst.SetActive(true);
        yield return new WaitForSeconds(6);
        butterflyInst.SetActive(false);
        butterflyInst.GetComponent<boss_butterfly_v2>().isActive = false;
        yield return null;

        //UBW
        UBWInst.SetActive(true);
        yield return new WaitForSeconds(4);
        UBWInst.SetActive(false);
        UBWInst.GetComponent<boss_UBW>().isActive = false;
        yield return null;

        //鎖鏈
        chainInst.SetActive(true);
        yield return new WaitForSeconds(4);
        chainInst.SetActive(false);
        chainInst.GetComponent<boss_chain>().isActive = false;
        yield return null;

    }

    IEnumerator attack10()
    {
        //蝴蝶彈幕
        chainInst.SetActive(false);
        UBWInst.SetActive(false);

        butterflyInst.SetActive(true);
        activateTorch.SetActive(true);
        yield return new WaitForSeconds(2);
        InvokeRepeating("chargeSoundEffect", 0, 2f);

        for (int i = 0; i < 12; i++)
        {
            GameObject charge_clone = Instantiate(final_charge, new Vector3(33.54f, 11.1f, 1f), new Quaternion(0, 0, 0, 0));
            yield return new WaitForSeconds(2f);
            Destroy(charge_clone, 0);
            

        }

        //即死全圖炸


        yield return null;
    }

    private void chargeSoundEffect()
    {
        chargeCnt += 1;
        GetComponent<AudioSource>().PlayOneShot(chargeSound);
    }
}
