using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayStill : MonoBehaviour {
    public float inposx;
    public float inposy;
    public float inposz;
    public bool lockx;
    public bool locky;
    public bool lockz;
    public float posx;
    public float posy;
    public float posz;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {

        if (lockx) {
            posx = inposx;
        }
        else {
            posx = transform.position.x;
        }
        if (locky)
        {
            posy = inposy;
        }
        else
        {
            posy = transform.position.y;
        }
        if (lockz)
        {
            posz = inposz;
        }
        else
        {
            posz = transform.position.z;
        }



        transform.position = new Vector3(posx, posy, posz);
	}
}
