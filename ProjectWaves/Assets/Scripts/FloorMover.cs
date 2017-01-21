using UnityEngine;
using System.Collections;

public class FloorMover : MonoBehaviour {
    private Rigidbody rb;
    public float speed;
    public float lifetime;
    public float destroyPosition; // z position to destory the object at
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, lifetime);

        destroyPosition = transform.position.z + destroyPosition;
    }

    void FixedUpdate () {
    
        rb.velocity = new Vector3(0f, 0.0f, speed);

        if (transform.position.z > destroyPosition)
            Destroy(gameObject);
    }
}
