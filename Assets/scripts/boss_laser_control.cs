using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_laser_control : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject laser;
    public float eventHp;
    private float Boss_Life_Num;

    private bool isInst = false;



    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //Boss_Life_Num = GameObject.Find("boss").GetComponent<boss_collision>().Boss_Life_Num;
        //Debug.Log(Boss_Life_Num);
        if (isInst == false)
        {
            isInst = true;
            GameObject laser_clone = Instantiate(laser, new Vector3(0, 0, 0), transform.rotation);
            laser_clone.transform.SetParent(this.gameObject.transform, false);
            Destroy(gameObject, 6f);
        }
    }
}
