using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_pencil_atk : MonoBehaviour
{
    public GameObject pencil;
    public float Time_Num;
    public AudioClip pencilSound;
    private float i;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Game_State.State == true)
        //{
        if (Input.GetKey(KeyCode.E))
        {
            i += Time.deltaTime;
            if (i >= Time_Num)
            {
                GetComponent<AudioSource>().PlayOneShot(pencilSound, 0.3f);
                Instantiate(pencil, transform.position, new Quaternion(0, 0, 0, 0));
                i = 0;
            }
        }
        //}
    }
}
