using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_appleDrop : MonoBehaviour
{
    public GameObject[] Fruit;
    public float screen_min;
    public float screen_max;
    public float Sec = 2;
    private Vector3 X_Num;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SetInterial", 0f, Sec);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetInterial()
    {
    
        X_Num.x = Random.Range(-15, 15);
        transform.position += new Vector3(X_Num.x, 0, 0);
        if (transform.position.x > screen_max)
        {
            transform.position = new Vector3(screen_max, transform.position.y, 0);
        }

        if (transform.position.x < screen_min)
        {
            transform.position = new Vector3(screen_min, transform.position.y, 0);
        }

        i = Random.Range(0, 2);

        if (i == 0)
        {
            Instantiate(Fruit[0], transform.position, transform.rotation);
        }

        else if (i == 1)
        {
            Instantiate(Fruit[1], transform.position, transform.rotation);
        }
    }
    
}
