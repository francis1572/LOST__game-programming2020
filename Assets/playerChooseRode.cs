using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerChooseRode : MonoBehaviour
{
    // Start is called before the first frame update
    public player_move_in_book_one player_move_in_book_one;
    public float speed;
    public GameObject left_arrow;
    public GameObject right_arrow;
    public Fungus.Flowchart story_flowchart;
    public sceneController sceneController;
    public GameObject fog;
    private Vector3 target_direction;
    void Start()
    {
        
        fog = GameObject.Find("fog");
        sceneController = GameObject.Find("bg").GetComponent<sceneController>();
    }

    // Update is called once per frame
    void Update()
    {

        choose_right_road();
        choose_left_road();
        //if (rode_pick == new List<string>() { "right", "left"})
        //{
        //    Debug.Log("finished");
        //}
    }
    public void check_correct()
    {
        if (stringEquals(sceneController.road_picks, sceneController.true_road))
        {
            story_flowchart.ExecuteBlock("leave_cave");
        }
        else if(sceneController.road_picks.Count >= sceneController.true_road.Count)
        {
            story_flowchart.ExecuteBlock("missing_road");
            StartCoroutine(wait_seconds());
        }
        else
        {
            SceneManager.LoadScene("firstbook_cave", LoadSceneMode.Single);
        }
    }
    private IEnumerator wait_seconds()
    {
        sceneController.road_picks = new List<string>() { };
        sceneController.str_road_picks = "";
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("firstbook_cave", LoadSceneMode.Single);

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
    public void decide_pick()
    {
        
        if(sceneController.str_road_picks != "")
        {
            story_flowchart.SetBooleanVariable("already_walk", true);
            story_flowchart.SetStringVariable("walk_path", sceneController.str_road_picks);
        }
        else
        {
            story_flowchart.SetBooleanVariable("already_walk", false);
        }
       
    }
    public void add_pick_road()
    {
        if(story_flowchart.GetBooleanVariable("already_pick") == false && story_flowchart.GetBooleanVariable("right") == true)
        {
            sceneController.road_picks.Add("右邊");
            sceneController.str_road_picks += " 右邊";
            
        }
        else if (story_flowchart.GetBooleanVariable("already_pick") == false && story_flowchart.GetBooleanVariable("left") == true)
        {
            sceneController.road_picks.Add("左邊");
            sceneController.str_road_picks += " 左邊";
        }
        story_flowchart.SetBooleanVariable("already_pick", true);

    }
    public void choose_right_road()
    {
        
        if(story_flowchart.GetBooleanVariable("right") == true)
        {
            
            right_arrow.GetComponent<SpriteMask>().enabled = false;
            target_direction = right_arrow.transform.position - new Vector3(0, 5, 0);
            StartCoroutine(move_to_road(target_direction));
            
        }

    }
    public void choose_left_road()
    {
        if (story_flowchart.GetBooleanVariable("left") == true)
        {
            left_arrow.GetComponent<SpriteMask>().enabled = false;
            target_direction = left_arrow.transform.position - new Vector3(0, 5, 0);
            StartCoroutine(move_to_road(target_direction));
        }

    }

    private IEnumerator move_to_road(Vector3 target_direction)
    {
        yield return new WaitForSeconds(0.1f);
        player_move_in_book_one.enabled = false;
        this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, target_direction, 1);
    }

    private void disappear()
    {
        Color oringinal_color = this.gameObject.GetComponent<SpriteRenderer>().color;
        if (Vector3.Distance(this.gameObject.transform.position, target_direction) < 0.1)
        {
            StartCoroutine(gradually_turn_black(oringinal_color));
        }
    }
    public IEnumerator gradually_turn_black(Color oringinal_color)
    {

        // disappear player
        yield return new WaitForSeconds(0f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(oringinal_color, new Color(255f, 255f, 255f, 0.1f), Mathf.PingPong(Time.time, 3));

        //// disapper cake
        if (GameObject.Find("cake") != null)
        {
            GameObject.Find("cake").GetComponent<SpriteRenderer>().color = Color.Lerp(oringinal_color, new Color(255f, 255f, 255f, 0.1f), Mathf.PingPong(Time.time, 3));

        }

        // make fog the front and disappear fog
        fog.GetComponent<SpriteRenderer>().color = Color.Lerp(fog.GetComponent<SpriteRenderer>().color, new Color(0f, 0f, 0f, 1f), Mathf.PingPong(Time.time, 3));
        check_correct();
    }
    public void set_eat()
    {
        story_flowchart.SetBooleanVariable("eat", sceneController.eat);
    }
    public void set_eat_true()
    {
        sceneController.eat = true;
    }
}
