using UnityEngine;
using System.Collections;

public class FloorSpawner : MonoBehaviour {
    public GameObject thingToSpawn;

    public float spawnRate = 5.0f;
    public float countDownToSpawn;

    public float destroyPosition;

    // Use this for initialization


    void Update () {

        countDownToSpawn--;

        if ( countDownToSpawn < 0.0f)
        {
            GameObject x = Instantiate(thingToSpawn);
            x.transform.position = new Vector3(0f,gameObject.transform.position.y, gameObject.transform.position.z);
            x.GetComponent<FloorMover>().destroyPosition = destroyPosition;
            countDownToSpawn = spawnRate;
        }
       
    }
}
