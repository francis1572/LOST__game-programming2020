using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_chain : MonoBehaviour
{
    public GameObject chainLine;
    public GameObject chainBox;
    public List<Vector3> instPoint;
    public AudioClip chainSound;
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
            StartCoroutine(chain());
            isActive = true;

        }
    }

    IEnumerator chain()
    {
        GameObject chainLine_clone = Instantiate(chainLine, new Vector3(31.9f, 2.2f, 1f), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(2f);
        Destroy(chainLine_clone, 0);
        Instantiate(chainBox, new Vector3(31.9f, 2.2f, 1f), new Quaternion(0, 0, 0, 0));
        GetComponent<AudioSource>().PlayOneShot(chainSound);
        yield return null;
    }
}
