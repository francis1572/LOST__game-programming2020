using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_flash : MonoBehaviour
{
    public GameObject boss;
    public GameObject flash_light;
    public GameObject flash_fire;
    public GameObject flash_collider;
    public Vector3 boss_pos1;
    public Vector3 boss_pos2;
    public Vector3 boss_pos3;
    public Vector3 boss_pos4;
    public Vector3 boss_pos5;
    public bool isActive = false;

    public AudioClip flashSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive == false)
        {
            isActive = true;
            StartCoroutine(flash());
        }
    }

    IEnumerator flash()
    {
        GameObject flash1 = Instantiate(flash_light, boss_pos1, new Quaternion(0, 0, 0, 0));
        GameObject col11 = Instantiate(flash_collider, boss_pos1, new Quaternion(0, 0, 0, 0));
        boss.gameObject.transform.position = boss_pos2;
        GameObject fire1 = Instantiate(flash_fire, boss_pos2, new Quaternion(0, 0, 0, 0));
        GetComponent<AudioSource>().PlayOneShot(flashSound);
        yield return new WaitForSeconds(1.5f);
        Destroy(col11, 0);
        GameObject col1 = Instantiate(flash_collider, boss_pos2, new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(1.0f);
        Destroy(flash1, 0);
        Destroy(fire1, 0);
        Destroy(col1, 0);

        GameObject flash2 = Instantiate(flash_light, boss_pos2, new Quaternion(0, 0, 0, 0));
        GameObject col21 = Instantiate(flash_collider, boss_pos2, new Quaternion(0, 0, 0, 0));
        boss.gameObject.transform.position = boss_pos3;
        GameObject fire2 = Instantiate(flash_fire, boss_pos3, new Quaternion(0, 0, 0, 0));
        GetComponent<AudioSource>().PlayOneShot(flashSound);
        yield return new WaitForSeconds(1.5f);
        Destroy(col21, 0);
        GameObject col2 = Instantiate(flash_collider, boss_pos3, new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(1.0f);
        Destroy(flash2, 0);
        Destroy(fire2, 0);
        Destroy(col2, 0);

        GameObject flash3 = Instantiate(flash_light, boss_pos3, new Quaternion(0, 0, 0, 0));
        GameObject col31 = Instantiate(flash_collider, boss_pos3, new Quaternion(0, 0, 0, 0));
        boss.gameObject.transform.position = boss_pos4;
        GameObject fire3 = Instantiate(flash_fire, boss_pos4, new Quaternion(0, 0, 0, 0));
        GetComponent<AudioSource>().PlayOneShot(flashSound);
        yield return new WaitForSeconds(1.5f);
        Destroy(col31, 0);
        GameObject col3 = Instantiate(flash_collider, boss_pos4, new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(1.0f);
        Destroy(flash3, 0);
        Destroy(fire3, 0);
        Destroy(col3, 0);

        GameObject flash4 = Instantiate(flash_light, boss_pos4, new Quaternion(0, 0, 0, 0));
        GameObject col41 = Instantiate(flash_collider, boss_pos4, new Quaternion(0, 0, 0, 0));
        boss.gameObject.transform.position = boss_pos5;
        GameObject fire4 = Instantiate(flash_fire, boss_pos5, new Quaternion(0, 0, 0, 0));
        GetComponent<AudioSource>().PlayOneShot(flashSound);
        yield return new WaitForSeconds(1.5f);
        Destroy(col41, 0);
        GameObject col4 = Instantiate(flash_collider, boss_pos5, new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(1.0f);
        Destroy(flash4, 0);
        Destroy(fire4, 0);
        Destroy(col4, 0);

        GameObject flash5 = Instantiate(flash_light, boss_pos5, new Quaternion(0, 0, 0, 0));
        GameObject col51 = Instantiate(flash_collider, boss_pos5, new Quaternion(0, 0, 0, 0));
        boss.gameObject.transform.position = boss_pos1;
        GameObject fire5 = Instantiate(flash_fire, boss_pos1, new Quaternion(0, 0, 0, 0));
        GetComponent<AudioSource>().PlayOneShot(flashSound);
        yield return new WaitForSeconds(1.5f);
        Destroy(col51, 0);
        GameObject col5 = Instantiate(flash_collider, boss_pos1, new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(1.0f);
        Destroy(flash5, 0);
        Destroy(fire5, 0);
        Destroy(col5, 0);

        yield return null;
    }
}
