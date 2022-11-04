using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_tri_atk : MonoBehaviour
{
    public GameObject tri;
    public float Time_Num;
    public AudioClip triSound;
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
        if (Input.GetKey(KeyCode.Q))
        {
            i += Time.deltaTime;
            if (i >= Time_Num)
            {
                GetComponent<AudioSource>().PlayOneShot(triSound);
                GameObject tri_clone = Instantiate(tri, new Vector3(0, 0, 0), transform.rotation);
                tri_clone.transform.SetParent(this.gameObject.transform, false);
                i = 0;
            }
        }
        //}
    }
}