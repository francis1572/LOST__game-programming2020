using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerFall : MonoBehaviour
{
    // Start is called before the first frame update
    public Fungus.Flowchart story_flowchart;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "holeColiider")
        {
            StartCoroutine(fall_to_cave());
        }
        
    }
    public IEnumerator fall_to_cave()
    {
        story_flowchart.ExecuteBlock("fall_to_hole");
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("firstbook_cave");
    }
    
}
