using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour {

    public static int score;

    public static int Health = 10;
    public Transform Star;
    public Transform Enemy;
  
    bool playerDead = false;

    AudioSource audioSource;

    public AudioClip[] audio;
    public AudioClip[] endSounds;
    public AudioClip collectSound;


    
    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
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
            audioSource.clip = endSounds[Random.Range(0, endSounds.Length)];
            audioSource.Play();
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
                Transform newStar = Instantiate(Star, transform.position, Quaternion.identity) as Transform;
                Destroy(newStar.gameObject, 5.0f);
                Destroy(col.gameObject);
                increaseScore(10);
                Debug.Log("Collect");
                audioSource.clip = collectSound;
                audioSource.Play();
            }
            else if (col.gameObject.tag == "Destructable")
            {
                //player collides and destroys destructable
                Transform newEnemy = Instantiate(Enemy, transform.position, Quaternion.identity) as Transform;
                Destroy(newEnemy.gameObject, 5.0f);
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
