using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_collision : MonoBehaviour
{
    public float Player_Life_Num;
    public Slider player_hp;
    public GameObject Fill_Area;
    public Animator player_animator;
    public AudioClip touchSpike;
    // public GameObject activateTorch;

    public bool isDead = false;
    public Fungus.Flowchart flowchart;

    public AudioClip beatenSound;

    //public GameObject Trigger1_Enemy;
    //public GameObject Trigger2_Enemy;
    //public GameObject Trigger3_Enemy;
    //public GameObject UFO_BOSS;
    //public GameObject UFO_Life;

    // Start is called before the first frame update
    void Start()
    {
        //Player_Life_Num = 100;
    }

    // Update is called once per frame
    void Update()
    {
        player_hp.value = Player_Life_Num;
        if (Player_Life_Num < 0.09 && isDead == false)
        {
            isDead = true;
            Fill_Area.SetActive(false);
            GetComponent<AudioListener>().enabled = false;
            Camera.main.GetComponent<AudioListener>().enabled = true;
            GameObject activate_torches = GameObject.Find("Torches");
            if (activate_torches != null)
            {
                Destroy(activate_torches);
            }
            //activateTorch.SetActive(false);
            flowchart.ExecuteBlock("dead");
            gameObject.SetActive(false);
            //Destroy(gameObject, 0.2f);

        }

        Color tmp = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = tmp;
        tmp.a = 125;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Get_Rocket")
        //{
        //    Score_Total.Rocket_Num += 1;
        //    Destroy(collision.gameObject);
        //    GetComponent<AudioSource>().PlayOneShot(Get_Rocket_Sound);

        //}

        if (collision.gameObject.tag == "boss_books")
        {
            Player_Life_Num -= 12f;
            //Debug.Log(Player_Life_Num);
            GetComponent<AudioSource>().PlayOneShot(beatenSound);
            StartCoroutine(Alpha());

        }
        if (collision.gameObject.tag == "boss_bad_apple")
        {
            Player_Life_Num -= 5f;
            //Debug.Log(Player_Life_Num);
            StartCoroutine(Alpha());
            //GetComponent<AudioSource>().PlayOneShot(beatenSound);

        }
        if (collision.gameObject.tag == "boss_good_apple")
        {
            Player_Life_Num += 10f;
            //Debug.Log(Player_Life_Num);
            //StartCoroutine(Beta());
            //GetComponent<AudioSource>().PlayOneShot(beatenSound);

        }

        if (collision.gameObject.tag == "boss_pen")
        {
            Player_Life_Num -= 10f;
            //Debug.Log(Player_Life_Num);
            GetComponent<AudioSource>().PlayOneShot(beatenSound);
            StartCoroutine(Alpha());

        }

        if (collision.gameObject.tag == "spear")
        {
            Player_Life_Num -= 7.5f;
            InvokeRepeating("hurt", 0, 1.5f);
            StartCoroutine(Alpha());
        }

        if (collision.gameObject.tag == "FINALBLAZE")
        {
            Player_Life_Num -= 9999f;

        }

        if (collision.gameObject.tag == "boss_cat")
        {
            Player_Life_Num -= 15f;
            GetComponent<AudioSource>().PlayOneShot(beatenSound);
            StartCoroutine(Alpha());
        }

        if (collision.gameObject.tag == "boss_laser")
        {
            Player_Life_Num -= 30f;
            //Debug.Log("-30");
            GetComponent<AudioSource>().PlayOneShot(beatenSound);
            StartCoroutine(Alpha());
        }

        if (collision.gameObject.tag == "boss_spark")
        {
            Player_Life_Num -= 5f;
            //Debug.Log("-30");
            GetComponent<AudioSource>().PlayOneShot(beatenSound);
            StartCoroutine(Alpha());
        }

        if (collision.gameObject.tag == "binding_obj")
        {
            Player_Life_Num -= 20f;
            GetComponent<AudioSource>().PlayOneShot(beatenSound);
            StartCoroutine(getBinded());
        }

        //if (collision.gameObject.tag == "Laser")
        //{
        //    Player_Life_Num -= 0.1f;
        //    GetComponent<AudioSource>().PlayOneShot(Hit_Sound);
        //    StartCoroutine(Alpha());
        //    Destroy(collision.gameObject);

        //}

        //if (collision.gameObject.tag == "Trigger1")
        //{
        //    Trigger1_Enemy.SetActive(true);
        //}

        //if (collision.gameObject.tag == "Trigger2")
        //{
        //    Trigger2_Enemy.SetActive(true);
        //}

        //if (collision.gameObject.tag == "Trigger3")
        //{
        //    Trigger3_Enemy.SetActive(true);
        //}

        //if (collision.gameObject.tag == "Trigger4")
        //{
        //    UFO_BOSS.SetActive(true);
        //    UFO_Life.SetActive(true);
        //}
        if (collision.gameObject.tag == "rope") {
            player_animator.SetInteger("climb", 1);
        }
    }

    private void OnTriggerStay2D(Collider2D tri_collision)
    {
        if (tri_collision.gameObject.tag == "spear")
        {
            Player_Life_Num -= 1.5f * Time.deltaTime;
        }
    }

    public void AlertObservers(string message)
    {
        if (message.Equals("climb end"))
        {
            player_animator.SetInteger("climb", 2);
            // Do other things based on an attack ending.
        }
    }

    private void OnTriggerExit2D(Collider2D exit_collision)
    {
        if (exit_collision.gameObject.tag == "spear")
        {
            CancelInvoke("hurt");
        }
    }

    private void hurt()
    {
        GetComponent<AudioSource>().PlayOneShot(touchSpike, 0.7f);
    }

    //public void AnimationStop(string message)
    //{
    //    if (message.Equals("climb end"))
    //    {
    //        player_animator.SetInteger("climb", 2);
    //        // Do other things based on an attack ending.
    //    }
    //}

    IEnumerator Alpha()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
    }

    IEnumerator getBinded()
    {
        //Debug.Log("我被綁了！！");
        gameObject.GetComponent<player_move>().enabled = !gameObject.GetComponent<player_move>().enabled;
        gameObject.GetComponent<player_move>().playerAni.SetInteger("tied", 1);
        yield return new WaitForSeconds(3f);
        gameObject.GetComponent<player_move>().playerAni.SetInteger("tied", 0);
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<player_move>().enabled = !gameObject.GetComponent<player_move>().enabled;
        
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
    }
}
