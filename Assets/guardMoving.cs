using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardMoving : MonoBehaviour
{
    // Start is called before the first frame update
    public cashOnFloor cashOnFloor;
    public float moving_speed;
    private float total_walk;
    private Vector3 theScale;
    private float guard_direction;
    public GameObject cash;
    public GameObject flashlight_spot;
    void Start()
    {
        total_walk = 0;
        theScale = this.gameObject.transform.localScale;
        
        if (this.gameObject.transform.rotation.y == 0)
        {
            guard_direction = -1;
        }
        else
        {
            guard_direction = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cashOnFloor.isDrop != true)
        {
            guard_surface_moving();
        }
        else
        {
            goTowardMoney();
        }
        
    }
    private void guard_surface_moving()
    {
        this.gameObject.GetComponent<Animator>().enabled = true;
        if (total_walk > 30)
        {
            theScale.x *= -1;
            this.gameObject.transform.localScale = theScale;
            total_walk = 0;
        }
        if (theScale.x * guard_direction <= 0)
        {
            this.gameObject.transform.position -= new Vector3(moving_speed, 0, 0);

        }
        else if (theScale.x * guard_direction >= 0)
        {
            this.gameObject.transform.position += new Vector3(moving_speed, 0, 0);
        }
        total_walk += moving_speed;
    }
    public void goTowardMoney()
    {
        check_direction();
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, cashOnFloor.dropPosition, 0.1f);
        this.gameObject.GetComponent<Animator>().enabled = false;
        StartCoroutine(stop_seconds(10));
        //flashlight_spot.transform.rotation = new Quaternion(0f, 0f, guard_direction * -15f, 1f);
    }
    private void check_direction()
    {
        //Debug.Log(this.gameObject.name);
        //Debug.Log(theScale.x * guard_direction);
        
        float direction_x = cashOnFloor.dropPosition.x - this.gameObject.transform.position.x;
        //Debug.Log(direction_x);
        if ((direction_x < 0 && theScale.x * guard_direction > 0) || (direction_x > 0 && theScale.x * guard_direction < 0))
        {
            theScale.x *= -1;
            this.gameObject.transform.localScale = theScale;
        }

    }
    public IEnumerator stop_seconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        for(int i =0; i< cashOnFloor.cash_list.Count; i++)
        {
            Destroy(cashOnFloor.cash_list[i]);
        }
        cashOnFloor.isDrop = false;


    }
}
