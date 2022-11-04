using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class add_tone : MonoBehaviour
{
    // Start is called before the first frame update
    public music_check guess;
    public AudioSource audioData;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void add()
    {
        guess.guess.Add(this.gameObject.name);
        audioData.Play();
        //Debug.Log(guess.guess[0]);
    }
}
