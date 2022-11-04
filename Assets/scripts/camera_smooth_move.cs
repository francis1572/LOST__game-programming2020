using UnityEngine;
using System.Collections;

public class camera_smooth_move : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void move()
    {
        Destroy(GetComponent<CameraFollow>());
    }
    private void add_follow()
    {
        Destroy(GetComponent<Animator>());
        transform.gameObject.AddComponent<CameraFollow>();
        Camera.main.GetComponent<CameraFollow>().maxXAndY = new Vector2(5f, -0.17f);
        Camera.main.GetComponent<CameraFollow>().minXAndY = new Vector2(-4.31f, -0.17f);
    }
}
