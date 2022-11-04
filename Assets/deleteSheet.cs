using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteSheet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void destroy_prefab()
    {
        if (GameObject.Find("sheet_music(Clone)") == null)
            return;
        Destroy(GameObject.Find("sheet_music(Clone)"));
        Destroy(GameObject.Find("fog(Clone)"));

    }
}
