using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flower_besides : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> beside_flowers;
    public Fungus.Flowchart story_flowchart;
    public Sprite flower_bloom;
    public Sprite flower_wither;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void flower_change()
    {
        for (int i=0; i<beside_flowers.Count; i++)
        {
            
            if(beside_flowers[i].GetComponent<SpriteRenderer>().sprite.name == "flower_bloom")
            {
                beside_flowers[i].GetComponent<SpriteRenderer>().sprite = flower_wither;
                story_flowchart.SetIntegerVariable("bloom_number", story_flowchart.GetIntegerVariable("bloom_number") - 1);

            }
            else if (beside_flowers[i].GetComponent<SpriteRenderer>().sprite.name == "flower_wither")
            {
                beside_flowers[i].GetComponent<SpriteRenderer>().sprite = flower_bloom;
                story_flowchart.SetIntegerVariable("bloom_number", story_flowchart.GetIntegerVariable("bloom_number") + 1);
            }
        }
        if (story_flowchart.GetIntegerVariable("bloom_number") == 0)
        {
            story_flowchart.ExecuteBlock("finish_pick_flower");
        }

    }
}
