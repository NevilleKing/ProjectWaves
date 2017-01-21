using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flapper : MonoBehaviour {

    public Rigidbody rb;
    float impulse;
    public float multiply;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        impulse = AudioInput.MicVolume * 6;
        if (impulse > 0.8f)
        {
            impulse = 0.8f;
        }
        rb.AddForce(transform.up * impulse * multiply);
        rb.AddForce(transform.forward * impulse * multiply);
    }
}
