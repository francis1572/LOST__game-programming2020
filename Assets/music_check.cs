using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music_check : MonoBehaviour
{
    // Start is called before the first frame update
    public List<string> guess;
    public List<string> answer;
    public Fungus.Flowchart story_flowchart;
    void Start()
    {
        answer = new List<string>() { "do", "do", "so", "so", "la", "la", "so"};
    }

    // Update is called once per frame
    void Update()
    {
        check();
    }
    public void check()
    {
        if (guess.Count == 0)
            return;
        if(!stringEquals(guess, GetFirstNElements(answer, guess.Count)))
        {
            guess = new List<string>() { };
        }
        else
        {
            if(guess.Count == answer.Count)
            {
                story_flowchart.ExecuteBlock("save_hunter");
            }
        }
    }
    public List<string> GetFirstNElements(List<string> list, int n)
    {
        n = Mathf.Min(n, list.Count);
        return list.GetRange(0, n);
    }
    static bool stringEquals(List<string> a, List<string> b)
    {
        if (a == null) return b == null;
        if (b == null || a.Count != b.Count) return false;
        for (int i = 0; i < a.Count; i++)
        {
            if (a[i] != b[i])
            {
                return false;
            }
        }
        return true;
    }
}
