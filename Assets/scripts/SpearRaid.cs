using UnityEngine;
using System.Collections;

public class SpearRaid : MonoBehaviour
{
    public float stopMinY;
    public int raidLR;
    public int raidUB;
    public int startTime;
    public int repeatInterval;
    public AudioClip spearSound;
    private Vector3 init;
    private bool startRaid;

    // Use this for initialization
    void Start()
    {
        startRaid = false;
        init = transform.position;
        if (repeatInterval != 0)
            InvokeRepeating("SpearRaidActivate", startTime, repeatInterval);
        else
            StartCoroutine(attackOnce());
    }

    // Update is called once per frame
    void Update()
    {
        if (startRaid)
        {
            transform.position += new Vector3(5 * 45 * Time.deltaTime * raidLR, 3 * 45 * Time.deltaTime * raidUB, 0.0f);
        }

        if (raidUB == -1)
        {
            if (transform.position.y <= stopMinY)
            {
                StartCoroutine(stopAndBack());
                startRaid = false;
            }
        }
        else
        {
            if (transform.position.y >= stopMinY)
            {
                StartCoroutine(stopAndBack());
                startRaid = false;
            }
        }
        
    }

    private void SpearRaidActivate()
    {
        startRaid = true;
        GetComponent<AudioSource>().PlayOneShot(spearSound, 1f);
    }

    private IEnumerator attackOnce()
    {
        yield return new WaitForSeconds(startTime);
        startRaid = true;
        GetComponent<AudioSource>().PlayOneShot(spearSound, 1f);
    }

    private IEnumerator stopAndBack()
    {
        yield return new WaitForSeconds(0.8f);
        transform.position = init;
    }
}
