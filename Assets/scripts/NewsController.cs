using UnityEngine;
using System.Collections;
using Fungus;

public class NewsController : MonoBehaviour
{
    public int[] newsStatus = new int[6];
    private float[,] newsposition = new float[,] { { -4.74f, -12.71f }, { -0.17f, -12.71f }, { 4.39f, -12.71f }, { -4.74f, -17.28f }, { -0.17f, -17.28f }, { 4.39f, -17.28f } };
    public GameObject[] news;
    public bool flag;
    private bool ifChange;
    private bool same;
    private GameObject news_3;
    private int[] correct = new int[] { 0, 1, 2, -1, 4, 5 };

    // Use this for initialization
    void Start()
    {
        newsStatus = new int[] {-1, 2, 5, 1, 0, 4};
        ifChange = false;
        same = false;
        news_3 = GameObject.Find("3");
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject e in news)
        {
            if (e.GetComponent<news_puzzle>().change == true)
            {
                ifChange = true;
                int prev = e.GetComponent<news_puzzle>().prev;
                int current = e.GetComponent<news_puzzle>().current;
                newsStatus[current] = int.Parse(e.name);
                newsStatus[prev] = -1;
                break;
            }
        }

        if (ifChange)
        {
            same = true;
            for (int i = 0; i < 6; i++)
            {
                if (newsStatus[i] != correct[i])
                {
                    same = false;
                    break;
                }
            }
            if (same && flag)
            {
                Flowchart.BroadcastFungusMessage("done");
                news_3.transform.position = new Vector3(newsposition[3, 0], newsposition[3, 1], 0);
                flag = false;
            }

            ifChange = false;
        }
    }
}
