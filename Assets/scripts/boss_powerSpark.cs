using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_powerSpark : MonoBehaviour
{
    public GameObject sparkLine;
    public GameObject sparkBox;
    public List<Vector3> instPoint;
    public AudioClip sparkSound;
    public bool isActive = false;

    private int soundCnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("soundEffect", 0, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive == false)
        {
            isActive = true;
            for(int i = 0; i < instPoint.Count; i++)
            {
                StartCoroutine(activate(instPoint));
            }
        }

        if (soundCnt == 2)
        {
            CancelInvoke();
        }
    }
    IEnumerator activate(List<Vector3> instPoint)
    {
        for (int i = 0; i < instPoint.Count; i++)
        {
            StartCoroutine(spark(instPoint[i]));
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator spark(Vector3 pos)
    {
        GameObject sparkLine_clone = Instantiate(sparkLine, pos, new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(1f);
        Destroy(sparkLine_clone, 0);
        Instantiate(sparkBox, pos, new Quaternion(0, 0, 0, 0));
        yield return null;
    }

    private void soundEffect()
    {
        soundCnt += 1;
        GetComponent<AudioSource>().PlayOneShot(sparkSound);
    }
}
