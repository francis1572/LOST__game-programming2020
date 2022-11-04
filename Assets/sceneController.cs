using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;
using UnityEngine.SceneManagement;
public class sceneController : MonoBehaviour
{
    static sceneController instance;
    public List<string> road_picks;
    public string str_road_picks;
    public List<string> true_road;
    public bool eat;
    void Awake()
    {
        if (instance == null)
        {
            instance = this; // In first scene, make us the singleton.
            road_picks = new List<string>() { };
            str_road_picks = "";
            true_road = new List<string>() { "右邊", "左邊", "左邊", "右邊" };
            eat = false;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);// On reload, singleton already set, so destroy duplicate
        }
            
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //string tmp = string.Join(", ", road_picks.ToArray());
        
    }
}