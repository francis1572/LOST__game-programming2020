using UnityEngine;
using System.Collections;

public class boss_hp10_torches : MonoBehaviour
{
    public GameObject torch;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(torch, new Vector3(133.3f, -18, -22.162f), new Quaternion(0, 0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
