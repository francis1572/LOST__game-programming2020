using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_butterfly_v2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject firPoint;
    public GameObject bullet;
    public AudioClip butterflySound;
    public bool isActive = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive == false){
            isActive = true;
            StartCoroutine(FirRoundGroup());
        }
        
    }
    GameObject CreatBullet(Vector3 bulletDir, Vector3 creatPoint)
    {
        GameObject tempBullet = Instantiate(bullet, creatPoint, transform.rotation);
        tempBullet.GetComponent<Butterfly_move>().dir = bulletDir;

        return tempBullet;
    }

    IEnumerator FirRound(int number,Vector3 creatPoint)//参数为发射波数与子弹生成点
    {
        Vector3 bulletDir = firPoint.transform.up;//发射方向
        Quaternion rotateQuate = Quaternion.AngleAxis(120, Vector3.forward);//使用四元数制造绕Z轴旋转10度的旋转
        for (int i=0;i< number; i++)    //发射波数
        {
            for (int j=0;j<3;j++)
            {
                CreatBullet(bulletDir, creatPoint);   //生成子弹
                bulletDir = rotateQuate * bulletDir; //让发射方向旋转10度，到达下一个发射方向
            }
            yield return new WaitForSeconds(1.5f); //协程延时，0.5秒进行下一波发射
        }
        yield return null;
    }
    
    IEnumerator FirRoundGroup()
    {
        Vector3 bulletDir = firPoint.transform.up;
        Quaternion rotateQuate = Quaternion.AngleAxis(45, Vector3.forward);//使用四元数制造绕Z轴旋转45度的旋转
        List<GameObject> bullets = new List<GameObject>();       //装入开始生成的8个弹幕
        GetComponent<AudioSource>().PlayOneShot(butterflySound);
        for (int i = 0; i < 8; i++)
        {
            var tempBullet = CreatBullet(bulletDir, firPoint.transform.position);
            bulletDir = rotateQuate * bulletDir; //生成新的子弹后，让发射方向旋转45度，到达下一个发射方向
            bullets.Add(tempBullet);
        }
        yield return new WaitForSeconds(1.0f);   //1秒后在生成多波弹幕
        for (int i = 0; i < bullets.Count; i++)
        {
            bullets[i].GetComponent<Butterfly_move>().Move_Speed = 0; //弹幕停止移动
            
        }
        yield return new WaitForSeconds(2.0f);   //1秒后在生成多波弹幕
        for (int i = 0; i < bullets.Count; i++)
        {
 
            StartCoroutine(FirRound(3, bullets[i].transform.position));//通过之前弹幕的位置，生成多波多方向的圆形弹幕。这里调用了上面写过的圆形弹幕函数
        }
    }
}
