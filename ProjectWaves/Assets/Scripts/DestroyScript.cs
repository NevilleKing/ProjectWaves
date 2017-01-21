using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
          // Limited time to avoid any leak
          Destroy(gameObject, 15); // 15sec
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
