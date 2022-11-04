using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_UBW : MonoBehaviour
{
    public GameObject UBW_obj1;
    public GameObject UBW_obj2;
    public GameObject explosion;
    public AudioClip ubwRaidSound;
    public AudioClip ubwExplodeSound;
    public bool isActive = false;

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
            StartCoroutine(UBW1());
        }
    }

    IEnumerator UBW1()
    {
        GameObject UBW1_clone = Instantiate(UBW_obj1, new Vector3(16.5f, 7.8f, 1f), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.5f);

        GameObject UBW2_clone = Instantiate(UBW_obj2, new Vector3(53f, -6.1f, 1f), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.8f);
        GetComponent<AudioSource>().PlayOneShot(ubwRaidSound);
        yield return new WaitForSeconds(0.2f);

        Destroy(UBW1_clone, 0);
        GameObject explode1 = Instantiate(explosion, new Vector3(16.5f, 7.8f, 1f), new Quaternion(0, 0, 0, 0));
        GetComponent<AudioSource>().PlayOneShot(ubwExplodeSound);
        yield return new WaitForSeconds(0.3f);
        GetComponent<AudioSource>().PlayOneShot(ubwRaidSound);
        yield return new WaitForSeconds(0.2f);
        Destroy(explode1, 0);
        Destroy(UBW2_clone, 0);

        GameObject explode2 = Instantiate(explosion, new Vector3(53f, -6.1f, 1f), new Quaternion(0, 0, 0, 0));
        GetComponent<AudioSource>().PlayOneShot(ubwExplodeSound);
        yield return new WaitForSeconds(0.5f);
        Destroy(explode2, 0);

        yield return null;
    }
}
