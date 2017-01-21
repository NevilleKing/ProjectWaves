using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour {

    protected int score;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col) {
        //Check collision name
        Debug.Log("collision name = " + col.gameObject.name);
        if (col.gameObject.tag == "Collectable") {
            //player collides and destroys collectable adding +10 score
            Destroy(col.gameObject);
            score += 10;
            Debug.Log("Collect");
        }
       else if (col.gameObject.tag == "Destructable") {
            //player collides and destroys destructable
            Destroy(col.gameObject);
            Debug.Log("Damage Hit!");
        }

    }
}
