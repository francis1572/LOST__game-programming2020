using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_skill_controller_1 : MonoBehaviour
{
    public float Sec = 30;

    public GameObject appleInst;
    public GameObject cat;
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
        yield return new WaitForSeconds(5);
        Destroy(appleInst_clone, 0);

        //突刺摧毀
        yield return new WaitForSeconds(5);
        Destroy(Spear1, 0);
        Destroy(Spear3, 0);


        //休息十秒
        yield return new WaitForSeconds(10);

        //突刺生成
        GameObject Spear2 = Instantiate(spears[1], new Vector3(89.4f, -47.8f, 1), Quaternion.Euler(new Vector3(0, 0, -75f)));
        GameObject Spear4 = Instantiate(spears[3], new Vector3(-16.3f, -49.7f, 1), Quaternion.Euler(new Vector3(0, 0, 75f)));

        //蘋果投擲十秒
        GameObject appleInst_clone2 = Instantiate(appleInst, new Vector3(32.5f, 23.9f, 1), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(5);
        Destroy(appleInst_clone2, 0);

        //突刺摧毀
        yield return new WaitForSeconds(5);
        Destroy(Spear2, 0);
        Destroy(Spear4, 0);

        //貓貓
        GameObject cat_clone = Instantiate(cat, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(3.9f);
        Destroy(cat_clone, 0);

        yield return null;
    }
}
