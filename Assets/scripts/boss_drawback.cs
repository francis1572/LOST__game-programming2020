using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_drawback : MonoBehaviour
{
    public List<GameObject> inks = new List<GameObject>();
    public List<Vector3> penDirs = new List<Vector3>();
    public bool isdraw = false;

    public GameObject drawbackLine;
    public GameObject drawbackBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isdraw == false)
        {
            StartCoroutine(DrawPen());
            isdraw = true;
            
        }
       
    }

    IEnumerator DrawPen()
    {
        GameObject drawbackLine_clone = Instantiate(drawbackLine, new Vector3(15.87752f, -12.48113f, 1f), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < inks.Count; i++)
        {
            Destroy(inks[i], 0);
        }
        Destroy(drawbackLine_clone, 0);
        inks = new List<GameObject>();
        penDirs = new List<Vector3>();
        Instantiate(drawbackBox, new Vector3(15.87752f, -12.48113f, 1f), new Quaternion(0, 0, 0, 0));
        yield return null;
    }
}
