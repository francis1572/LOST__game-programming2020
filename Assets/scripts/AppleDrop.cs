using UnityEngine;
using System.Collections;

public class AppleDrop : MonoBehaviour
{
    public GameObject[] Fruit;
    public float screen_min;
    public float screen_max;
    public float delete_time;
    public float Sec = 0.5f;
    public int range;
    private Vector3 initPosition;
    private GameObject e;
    private int X_Num;
    private int i;

    // Use this for initialization
    void Start()
    {
        initPosition = transform.position;
        InvokeRepeating("AppleInterial", 0f, Sec);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void AppleInterial()
    {
        X_Num = Random.Range(-1*range, range);
        transform.position = initPosition + new Vector3(X_Num, 0, 0);
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
            e = Instantiate(Fruit[0], transform.position, transform.rotation);
        }

        else if (i == 1)
        {
            e = Instantiate(Fruit[1], transform.position, transform.rotation);
        }

        StartCoroutine(destroy(e));
    }

    private IEnumerator destroy(GameObject e)
    {
        yield return new WaitForSeconds(delete_time);
        Destroy(e);
    }
}
