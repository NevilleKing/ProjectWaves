using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour {

    public static int score;
    public static int Health = 100;

    bool playerDead = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Health <= 0 && !playerDead) {
            playerDead = true;
            Debug.Log("GAME OVER!");
            Animator anim = GameObject.Find("eyes").GetComponent<Animator>();
            anim.SetTrigger("PlayerDead");
        }
            
	}

    public static void increaseScore(int scoreIncrease)
    {
        score += scoreIncrease;
    }

    void OnCollisionEnter(Collision col) {
        if (!playerDead)
        {
            //Check collision name
            Debug.Log("collision name = " + col.gameObject.name);
            if (col.gameObject.tag == "Collectable")
            {
                //player collides and destroys collectable adding +10 score
                Destroy(col.gameObject);
                increaseScore(10);
                Debug.Log("Collect");
            }
            else if (col.gameObject.tag == "Destructable")
            {
                //player collides and destroys destructable
                Destroy(col.gameObject);
                Debug.Log("Damage Hit!");
                Health -= 10;
            }
        }
    }

    void OnGUI() {
        GUI.Label(new Rect(10, 5, 100, 50), "Score: " + score);
        GUI.Label(new Rect(10, 25, 100, 50), "Health: " + Health);
    }
}
