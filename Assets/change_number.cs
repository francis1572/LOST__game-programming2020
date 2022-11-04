using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_number : MonoBehaviour
{
    // Start is called before the first frame update
    private int current_idx;
    public List<Sprite> number_pics;
    public GameObject number;
    public AudioClip kalaSound;

    void Start()
    {
        current_idx = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int get_current_idx()
    {
       
        return this.current_idx;
    }
    public void change()
    {
        GetComponent<AudioSource>().PlayOneShot(kalaSound);
        if (current_idx == (number_pics.Count-1))
        {
            current_idx = 0;
        }
        else
        {
            current_idx = current_idx + 1;
        }
        number.GetComponent<SpriteRenderer>().sprite = number_pics[current_idx];
    }
}
