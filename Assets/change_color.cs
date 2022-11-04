using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_color : MonoBehaviour
{
    // Start is called before the first frame update
    public dot_color all_color;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void change()
    {
        if (all_color.current_idx == all_color.color_order.Count)
        {
            all_color.reset_dot_color();
            return;
        }
        this.gameObject.GetComponent<SpriteRenderer>().color = all_color.color_order[all_color.current_idx];
        all_color.current_idx += 1;
    }
}
