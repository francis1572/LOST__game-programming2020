using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dot_color : MonoBehaviour
{
    // Start is called before the first frame update
    public int current_idx;
    public List<Color> color_order;
    private List<Color> true_order;
    public Fungus.Flowchart prefab_flowchart;
    void Start()
    {
        color_order = new List<Color>() { new Color(255, 255, 255), new Color(255, 0, 0), new Color(255, 255, 0), new Color(0, 0, 255) };
        true_order = new List<Color>() { new Color(255, 255, 255), new Color(255, 0, 0), new Color(255, 255, 0), new Color(0, 0, 255) };
    }

    // Update is called once per frame
    void Update()
    {
        if (current_idx == true_order.Count)
        {
            if (open_box() && !prefab_flowchart.GetBooleanVariable("open_box"))
            {
                prefab_flowchart.SetBooleanVariable("open_box", true);
                prefab_flowchart.ExecuteBlock("create_bomb");
            }
                
                
        }
    }
    public void reset_dot_color()
    {
        current_idx = 0;
        foreach (GameObject gameo in GameObject.FindGameObjectsWithTag("dot"))
        {
            gameo.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
        }
    }
    public bool open_box()
    {
        foreach(GameObject gaO in GameObject.FindGameObjectsWithTag("dot"))
        {
            string tmp_num = gaO.name[gaO.name.Length - 1].ToString();
            
            if (true_order[int.Parse(tmp_num) - 1] != gaO.GetComponent<SpriteRenderer>().color)
            {
                //Debug.Log("wrong");
                return false;
            }

        }
        return true;
    }
}
