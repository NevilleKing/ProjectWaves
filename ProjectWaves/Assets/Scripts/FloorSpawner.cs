using UnityEngine;
using System.Collections;

public class FloorSpawner : MonoBehaviour {
    public GameObject thingToSpawn;

    public float spawnRate = 5.0f;
    public float countDownToSpawn;

    public static float destroyPosition;
    public float _destroyPosition;

    // Use this for initialization

    private GameObject previousLine;

    private void Start()
    {
        destroyPosition = transform.position.z + _destroyPosition;
    }

    void Update () {

        countDownToSpawn--;

        if ( countDownToSpawn < 0.0f)
        {
            GameObject x = Instantiate(thingToSpawn);
            x.transform.position = new Vector3(0f,0f, gameObject.transform.position.z);
            if (previousLine != null)
            {
                LineRenderer lr = x.GetComponent<LineRenderer>();
                LineRenderer lastLR = previousLine.GetComponent<LineRenderer>();
                Vector3[] positions = { new Vector3(0f, gameObject.transform.position.y, gameObject.transform.position.z), new Vector3(0f, lastLR.GetPosition(0).y, previousLine.transform.position.z) };
                lr.SetPositions(positions);
                SphereCollider sc = x.GetComponent<SphereCollider>();
                sc.center = positions[0];
            }
            x.GetComponent<FloorMover>().destroyPosition = destroyPosition;
            previousLine = x;
            countDownToSpawn = spawnRate;
        }
       
    }
}
