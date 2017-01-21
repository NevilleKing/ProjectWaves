using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawning : MonoBehaviour
{
    public GameObject Collectable;
    GameObject SpawnedCollectable;
    public float TimerMin;
    public float TimerMax;
    public float TimerValue = 10.0f;
    float Timer;
    public float start_time;
    public float elapsed;
    public float speed = 5.0f;

    void Start()
    {
        Timer = Random.Range(TimerMin, TimerMax);
        start_time = 1000 * Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        Timer--;
        //Debug.Log (Timer);
        if (Timer <= 0)
        {
            //spawn here
            Debug.Log("Spawn");
            SpawnedCollectable = Instantiate(Collectable) as GameObject;
            SpawnedCollectable.transform.position = new Vector3(0, Random.Range(-10.0f, 10.0f), Random.Range(77.0f, 77.0f));
            SpawnedCollectable.GetComponent<MoveScript>().speed = new Vector3(0, 0, speed);
            Timer = Random.Range(TimerMin, TimerMax);

                                       
        }
        elapsed = Time.time - start_time; 
        if (elapsed >= TimerValue) //after 10 seconds
         {
            Debug.Log("Timer");
            speed += 0.5f;
            TimerValue += 10.0f;
         }
    }
}