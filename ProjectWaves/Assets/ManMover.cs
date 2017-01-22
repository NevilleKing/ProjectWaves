using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManMover : MonoBehaviour {
    private Rigidbody rb;
    private Vector3 dwn;
    public GameObject start;
    int layerMask = 1 << 6;
    private RaycastHit hit;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        dwn = transform.TransformDirection(Vector3.down);
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //Debug.DrawLine(start.transform.position, new Vector3(0, -40, 40), Color.red);
        Ray ray = new Ray (start.transform.position, dwn);
        if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Wave")
        {
            Debug.DrawLine(start.transform.position, hit.point, Color.red);
            rb.transform.position = hit.point + new Vector3(0, 0.15f, 0);
        }

    }
}
