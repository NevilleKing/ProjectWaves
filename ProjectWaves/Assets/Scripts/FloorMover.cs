using UnityEngine;
using System.Collections;

public class FloorMover : MonoBehaviour {
    private Rigidbody rb;
    public float speed;
    public float lifetime;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, lifetime);
    }

    void FixedUpdate () {
    
        rb.velocity = new Vector3(0f, 0.0f, speed);
    }
}
