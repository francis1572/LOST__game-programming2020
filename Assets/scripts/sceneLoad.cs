using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

public class sceneLoad : MonoBehaviour
{
    // Start is called before the first frame update
    public static Flowchart talkFlowchart;
    public string goAdress;
    public string goJackAdress;
    public string goAkaAdress;
    public string goMazeAdress;
    //public static Flowchart flowchartManager;
    private void Start()
    {
        //flowchartManager = GameObject.FindGameObjectWithTag("flowchartController").GetComponent<Flowchart>();
        talkFlowchart = GameObject.FindGameObjectWithTag("talkFlowchart").GetComponent<Flowchart>();
    }
    public static bool go
    {
        get { return talkFlowchart.GetBooleanVariable("go"); }
    }
    public static bool goJack
    {
        get { return talkFlowchart.GetBooleanVariable("goJack"); }
    }
    public static bool goAka
    {
        get { return talkFlowchart.GetBooleanVariable("goAka"); }
    }
    public static bool goMaze
    {
        get { return talkFlowchart.GetBooleanVariable("goMaze"); }
    }
    // Update is called once per frame
    void Update()
    {
        if (go)
        {
            if (goAdress == "lobby_stage_3" || goAdress ==  "lobby_stage_4")
            {
                string cur = SceneManager.GetActiveScene().name;
                CrossSceneClass.PreviousSceneName = cur;
            }
            SceneManager.LoadScene(goAdress);
        }
        if (goJack)
        {
            SceneManager.LoadScene(goJackAdress);
        }
        if (goAka)
        {
            SceneManager.LoadScene(goAkaAdress);
        }
        if (goMaze)
        {
            SceneManager.LoadScene(goMazeAdress);
        }
    }
}
