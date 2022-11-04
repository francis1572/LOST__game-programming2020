using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishing : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private bool direction = false;
    void Start()
    {
        player = GameObject.Find("player");
        direction = false;
    }

    // Update is called once per frame
    void Update()
    {
        start_fishing();
    }
    public void start_fishing()
    {
        

        if (direction == false)
        {
            
            rod_rotation(Quaternion.Euler(0.0f, this.gameObject.transform.rotation.eulerAngles.y, 45.0f), true);
        }
        else
        {
            rod_rotation(Quaternion.Euler(0.0f, this.gameObject.transform.rotation.eulerAngles.y, 0f), false);
        }
        
    }
    private void rod_rotation(Quaternion rotate_vector, bool flag)
    {
        float step = 1f * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotate_vector, 20f * Time.deltaTime);
        if (transform.rotation == rotate_vector)
        {
            direction = flag;
        }
    }
}
