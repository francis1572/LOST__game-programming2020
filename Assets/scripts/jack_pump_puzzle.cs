using UnityEngine;
using System.Collections;

public class jack_pump_puzzle : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            transfer_cam();
        }
        else
        {
            Camera.main.GetComponent<CameraFollow>().enabled = true;
        }
    }

    private void transfer_cam()
    {
        Camera.main.GetComponent<CameraFollow>().enabled = false;
        Camera.main.transform.position = new Vector3(3.3f, -17.74f, -10);
    }
}
