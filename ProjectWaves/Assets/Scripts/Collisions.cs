﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour {

    public static int score;

    public static int Health = 100;
    public Transform Star;
    public Transform Enemy;
  
    bool playerDead = false;

    AudioSource audioSource;

    public AudioClip[] audio;


    
    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();

        //audioSource.clip = audio;
    }
	
	// Update is called once per frame
	void Update () {
		if (Health <= 0 && !playerDead) {
            playerDead = true;
            Debug.Log("GAME OVER!");
            Animator anim = GameObject.Find("eyes").GetComponent<Animator>();
            anim.SetTrigger("PlayerDead");
            PlayerPrefs.SetInt("currentScore", score);
            PlayerPrefs.Save();
        }
            
	}

    public static void increaseScore(int scoreIncrease)
    {
        score += scoreIncrease;
    }

    void OnCollisionEnter(Collision col)
    {

        if (!playerDead)
        {
            //Check collision name
            Debug.Log("collision name = " + col.gameObject.name);
            if (col.gameObject.tag == "Collectable")
            {
                //player collides and destroys collectable adding +10 score
                Star = Instantiate(Star, transform.position, Quaternion.identity) as Transform;
                Destroy(col.gameObject);
                increaseScore(10);
                Debug.Log("Collect");
            }
            else if (col.gameObject.tag == "Destructable")
            {
                //player collides and destroys destructable
                Enemy = Instantiate(Enemy, transform.position, Quaternion.identity) as Transform;
                Destroy(col.gameObject);
                Debug.Log("Damage Hit!");
                Health -= 10;

                audioSource.clip = audio[Random.Range(0, audio.Length)];
                audioSource.Play();
            }
        }
    }

    void OnGUI() {
        GUI.Label(new Rect(10, 5, 100, 50), "Score: " + score);
        GUI.Label(new Rect(10, 25, 100, 50), "Health: " + Health);
    }
}
