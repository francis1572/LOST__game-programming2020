using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_skill_controller_3 : MonoBehaviour
{
    public float Sec = 74;

    public GameObject appleInst;
    public GameObject cat;
    public GameObject penInst;
    public GameObject sparkInst;
    public GameObject flashInst;
    public GameObject laserInst1;
    public GameObject laserInst2;
    public GameObject laserInst3;
    public GameObject laserInst4;
    public GameObject[] spears;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("looping", 0f, Sec);
    }

    // Update is called once per frame
    void Update()
    {
        //appleInst.SetActive(true);
    }

    void looping()
    {
        StartCoroutine(attackLoop());
    }
    IEnumerator attackLoop()
    {
        //突刺生成
        GameObject Spear1 = Instantiate(spears[0], new Vector3(92, 24.3f, 1), Quaternion.Euler(new Vector3(0, 0, 0)));
        GameObject Spear3 = Instantiate(spears[2], new Vector3(-30, 41.8f, 1), Quaternion.Euler(new Vector3(0, 0, 0)));

        //蘋果投擲十秒
        GameObject appleInst_clone = Instantiate(appleInst, new Vector3(32.5f, 23.9f, 1), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(2);
        Destroy(appleInst_clone, 0);
        yield return new WaitForSeconds(3);

        //突刺摧毀
        yield return new WaitForSeconds(5);
        Destroy(Spear1, 0);
        Destroy(Spear3, 0);

        //鋼筆投擲
        penInst.SetActive(true);
        yield return new WaitForSeconds(8);

        //貓貓
        GameObject cat_clone = Instantiate(cat, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(3.9f);
        Destroy(cat_clone, 0);

        //閃現
        flashInst.SetActive(true);
        yield return new WaitForSeconds(18);
        flashInst.SetActive(false);
        flashInst.GetComponent<boss_flash>().isActive = false;

        //鋼筆抽回
        penInst.GetComponent<boss_drawback>().isdraw = false;
        yield return new WaitForSeconds(2);
        penInst.SetActive(false);
        penInst.GetComponent<boss_pen>().isActive = false;

        //光砲
        sparkInst.SetActive(true);
        yield return new WaitForSeconds(6);
        sparkInst.SetActive(false);
        sparkInst.GetComponent<boss_powerSpark>().isActive = false;
        yield return null;

        //鋼筆投擲
        penInst.SetActive(true);
        yield return new WaitForSeconds(8);

        //突刺生成
        GameObject Spear2 = Instantiate(spears[1], new Vector3(89.4f, -47.8f, 1), Quaternion.Euler(new Vector3(0, 0, -75f)));
        GameObject Spear4 = Instantiate(spears[3], new Vector3(-16.3f, -49.7f, 1), Quaternion.Euler(new Vector3(0, 0, 75f)));

        //蘋果投擲十秒
        GameObject appleInst_clone2 = Instantiate(appleInst, new Vector3(32.5f, 23.9f, 1), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(2);
        Destroy(appleInst_clone2, 0);
        yield return new WaitForSeconds(3);

        //突刺摧毀
        yield return new WaitForSeconds(5);
        Destroy(Spear2, 0);
        Destroy(Spear4, 0);

        //鋼筆抽回
        penInst.GetComponent<boss_drawback>().isdraw = false;
        yield return new WaitForSeconds(2);
        penInst.SetActive(false);
        penInst.GetComponent<boss_pen>().isActive = false;

        //雷射掃蕩
        Instantiate(laserInst1, new Vector3(1.1f, 24.6f, 1f), new Quaternion(0, 0, -234.578f, 0));
        yield return new WaitForSeconds(2f);
        Instantiate(laserInst2, new Vector3(66.48f, -24.05f, 1f), new Quaternion(0, 0, -151.218f, 0));
        yield return new WaitForSeconds(2f);
        Instantiate(laserInst3, new Vector3(1.1f, -25.8f, 1f), new Quaternion(0, 0, -43.746f, 0));
        yield return new WaitForSeconds(2f);
        Instantiate(laserInst4, new Vector3(65.1f, 26.6f, 1f), new Quaternion(0, 0, -102.059f, 0));
        yield return new WaitForSeconds(7f);

        //閃現
        flashInst.SetActive(true);
        yield return new WaitForSeconds(18);
        flashInst.SetActive(false);
        flashInst.GetComponent<boss_flash>().isActive = false;
        
        

        //yield return null;
    }
}
