using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGrandmaDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite door_opened;
    public Fungus.Flowchart story_flowchart;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        check_door_lock();
    }
    public void check_door_lock()
    {
        try
        {
            GameObject flower_lock = GameObject.Find("flower_lock");
            GameObject fish_lock = GameObject.Find("fish_lock");
            GameObject waterwheel_lock = GameObject.Find("waterwheel_lock");
            
            if (flower_lock.GetComponent<change_number>().get_current_idx() == 8 && fish_lock.GetComponent<change_number>().get_current_idx() == 5 && waterwheel_lock.GetComponent<change_number>().get_current_idx() == 0)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = door_opened;
                this.gameObject.transform.localScale = new Vector3(0.8f, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
                this.gameObject.transform.position = new Vector3(-15.5f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                Destroy(flower_lock);
                Destroy(fish_lock);
                Destroy(waterwheel_lock);
                Destroy(GameObject.Find("reel"));
                StartCoroutine(wait_seconds());
                
            }
        }
        catch
        {
            //Debug.Log("bug");
        }
        
    }
    private IEnumerator wait_seconds()
    {
        GameObject.Find("doorSound").GetComponent<AudioSource>().Play();
        story_flowchart.ExecuteBlock("open_gate");
        yield return new WaitForSeconds(1f);
        GameObject gmDownCollider = GameObject.Find("gmDownCollider");
        gmDownCollider.GetComponent<BoxCollider2D>().isTrigger = false;
        GameObject.Find("player").transform.position = new Vector3(7, 0.5f, 0);
    }
    public void go_back_ground()
    {
        GameObject.Find("player").transform.position = new Vector3(-20, -12, GameObject.Find("player").transform.position.z);
    }
}
