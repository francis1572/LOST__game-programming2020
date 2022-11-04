using UnityEngine;
using System.Collections;

public class StepMoving : MonoBehaviour
{
    public float speed;
    public float radius;
    // public float initX;
    // public float initY;
    public float LR;
    private float count = 0.0f;
    private Transform player;

    // Use this for initialization
    void Start()
    {
        // transform.position = new Vector3(initX, initY, transform.position.z);
        float initLR = Random.Range(0, 1.0f);
        if (initLR >= 0.5)
        {
            LR = 1.0f;
        }
        else
        {
            LR = -1.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // starting from center, and go to right or left
        transform.position += new Vector3(LR * speed * Time.deltaTime, 0, 0);
        count += LR * speed * Time.deltaTime;

        // if move to right boundary or left boundary
        if ((LR == 1.0f && count >= radius) || (LR == -1.0f && count <= (-1) * radius))
        {
            LR *= -1;
        }
    }
}
