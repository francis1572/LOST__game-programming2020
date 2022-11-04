using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_pen : MonoBehaviour
{
    public GameObject firPoint;
    public GameObject pen;
    public GameObject ink;
    private Vector3 penDir;

    public bool isActive = false;
    

    // Start is called before the first frame update
    void Start()
    {
        penDir = -1 * firPoint.transform.up;//发射方向
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive == false)
        {
            StartCoroutine(ThrowPen());
            isActive = true;
        }
    }


    void CreatBullet(Vector3 bulletDir, Vector3 creatPoint)
    {
        GameObject tempBullet = Instantiate(pen, creatPoint, pen.GetComponent<Transform>().rotation);
        tempBullet.GetComponent<Butterfly_move>().dir = bulletDir;
        firPoint.GetComponent<boss_drawback>().penDirs.Add(bulletDir);

    }

    IEnumerator ThrowPen()//参数为发射波数与子弹生成点
{
        penDir = -1 * firPoint.transform.up;//发射方向
        Quaternion rotateQuate = Quaternion.AngleAxis(20, Vector3.forward);//使用四元数制造绕Z轴旋转10度的旋转
        for (int i = 0; i < 6; i++)    //发射波数
        {
            CreatBullet(penDir, firPoint.transform.position);   //生成子弹
            penDir = rotateQuate * penDir; //让发射方向旋转10度，到达下一个发射方向

            yield return new WaitForSeconds(1.5f); //协程延时，0.5秒进行下一波发射
        }
        yield return null;
    }
}
