using UnityEngine;
using System.Collections;
using Fungus;

public class news_puzzle : MonoBehaviour
{
    private float[,] newsposition = new float[,] {{-4.74f, -12.71f}, {-0.17f, -12.71f}, {4.39f, -12.71f}, {-4.74f, -17.28f}, {-0.17f, -17.28f},{4.39f, -17.28f}};
    public bool change;
    public int prev;
    public int current;
    private int[] status;
    private bool flag;
    // Use this for initialization
    void Start()
    {
        change = false;
        prev = -1;
        current = -1;
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        status = GameObject.Find("news").GetComponent<NewsController>().newsStatus;
        flag = GameObject.Find("news").GetComponent<NewsController>().flag;
    }

    private void OnMouseDown()
    {
        if (flag)
        {
            //Debug.Log(gameObject.name, gameObject);
            int ind = System.Array.IndexOf(status, int.Parse(gameObject.name));
            GameObject.Find("moveSound").GetComponent<AudioSource>().Play();
            check_space(ind, status);
        }
    }

    private void check_space(int pos, int[] status)
    {
        if (pos == 0)
        {
            if(status[1] == -1)
            {
                prev = 0;
                current = 1;
                transform.position = new Vector3(newsposition[1, 0], newsposition[1, 1], 0);
                change = true;
                StartCoroutine(revertChange());

            }
            else if(status[3] == -1)
            {
                prev = 0;
                current = 3;
                transform.position = new Vector3(newsposition[3, 0], newsposition[3, 1], 0);
                change = true;
                StartCoroutine(revertChange());
            }
        }
        else if(pos == 1)
        {
            if (status[0] == -1)
            {
                prev = 1;
                current = 0;
                transform.position = new Vector3(newsposition[0, 0], newsposition[0, 1], 0);
                change = true;
                StartCoroutine(revertChange());
            }
            else if(status[2] == -1)
            {
                prev = 1;
                current = 2;
                transform.position = new Vector3(newsposition[2, 0], newsposition[2, 1], 0);
                change = true;
                StartCoroutine(revertChange());
            }
            else if(status[4] == -1)
            {
                prev = 1;
                current = 4;
                transform.position = new Vector3(newsposition[4, 0], newsposition[4, 1], 0);
                change = true;
                StartCoroutine(revertChange());
            }
        }
        else if (pos == 2)
        {
            if (status[1] == -1)
            {
                prev = 2;
                current = 1;
                transform.position = new Vector3(newsposition[1, 0], newsposition[1, 1], 0);
                change = true;
                StartCoroutine(revertChange());
            }
            else if(status[5] == -1)
            {
                prev = 2;
                current = 5;
                transform.position = new Vector3(newsposition[5, 0], newsposition[5, 1], 0);
                change = true;
                StartCoroutine(revertChange());
            }
        }
        else if (pos == 3)
        {
            if (status[0] == -1)
            {
                prev = 3;
                current = 0;
                transform.position = new Vector3(newsposition[0, 0], newsposition[0, 1], 0);
                change = true;
                StartCoroutine(revertChange());
            }
            else if(status[4] == -1)
            {
                prev = 3;
                current = 4;
                transform.position = new Vector3(newsposition[4, 0], newsposition[4, 1], 0);
                change = true;
                StartCoroutine(revertChange());
            }
        }
        else if (pos == 4)
        {
            if (status[1] == -1)
            {
                prev = 4;
                current = 1;
                transform.position = new Vector3(newsposition[1, 0], newsposition[1, 1], 0);
                change = true;
                StartCoroutine(revertChange());
            }
            else if(status[3] == -1)
            {
                prev = 4;
                current = 3;
                transform.position = new Vector3(newsposition[3, 0], newsposition[3, 1], 0);
                change = true;
                StartCoroutine(revertChange());
            }
            else if(status[5] == -1)
            {
                prev = 4;
                current = 5;
                transform.position = new Vector3(newsposition[5, 0], newsposition[5, 1], 0);
                change = true;
                StartCoroutine(revertChange());
            }
        }
        else if (pos == 5)
        {
            if (status[2] == -1)
            {
                prev = 5;
                current = 2;
                transform.position = new Vector3(newsposition[2, 0], newsposition[2, 1], 0);
                change = true;
                StartCoroutine(revertChange());
            }
            else if (status[4] == -1)
            {
                prev = 5;
                current = 4;
                transform.position = new Vector3(newsposition[4, 0], newsposition[4, 1], 0);
                change = true;
                StartCoroutine(revertChange());
            }
        }
    }

    IEnumerator revertChange()
    {
        yield return new WaitForSeconds(0.1f);
        change = false;
    }
}
