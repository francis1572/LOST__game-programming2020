using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Move : MonoBehaviour
{
    public float Move_Speed;
    private float dir;
    // Start is called before the first frame update
    void Start()
    {
        dir = GameObject.Find("player").transform.localScale.x;
        this.gameObject.transform.Rotate(0, 0, 90);


    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(dir);
        //if (dir >= 0f){
        transform.Translate(Move_Speed * Time.deltaTime, 0, 0);
            
        //}
        //else if(dir <= 0f){
        //    transform.Translate(-1 * Move_Speed * Time.deltaTime, 0, 0);
        //    this.gameObject.transform.localScale = new Vector3(-0.2f, 0.3f, 0f);
        //}

        Destroy(gameObject, 1.5f);
    }
}
