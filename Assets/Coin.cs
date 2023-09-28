using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] GameObject controller; 
    [SerializeField] AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }
        if (audio == null)
        {
            audio = GetComponent<AudioSource>();
        }

   }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        //what should happen now?
        //1. count the coins or increase score
        //2.  play sound effect
        //3. coin should disapper

        //1. increase score
        controller.GetComponent<Scorekeeper>().AddPoints();

        //2. play sound effect
        AudioSource.PlayClipAtPoint(audio.clip, transform.position);

        //audio.Play() -- this will work but won't work if coin gets destroyed before audio is played.

        //3. destroy coin
        Destroy(gameObject);



    }
}
