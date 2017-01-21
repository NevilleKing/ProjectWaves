using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawning : MonoBehaviour
{
    public GameObject Collectable;
    public GameObject Destructable;
    GameObject SpawnedCollectable;
    GameObject SpawnedDestructable;
    public float TimerMin, TimerMax, TimerMin1, TimerMax1;
    public float TimerValue = 10.0f;
    float Timer1, Timer2;
    public float start_time;
    public float elapsed;
    public float speed = 5.0f;

    void Start()
    {
        Timer1 = Random.Range(TimerMin, TimerMax);
        Timer2 = Random.Range(TimerMin1, TimerMax1);
        start_time = 1000 * Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        Timer1--;
        if (Timer1 <= 0)
        {
            //spawn here
            Debug.Log("Spawn Collectable");
            SpawnedCollectable = Instantiate(Collectable) as GameObject;
            SpawnedCollectable.transform.position = new Vector3(0, Random.Range(-2.0f, 9.0f), Random.Range(77.0f, 77.0f));
            SpawnedCollectable.GetComponent<MoveScript>().speed = new Vector3(0, 0, speed);
            Timer1 = Random.Range(TimerMin, TimerMax);
        }
        Timer2--;
        if (Timer2 <= 0) {
            //spawn here
            Debug.Log("Spawn Destructable");
            SpawnedDestructable = Instantiate(Destructable) as GameObject;
            SpawnedDestructable.transform.position = new Vector3(0, Random.Range(-2.0f, 9.0f), Random.Range(77.0f, 77.0f));
            SpawnedDestructable.GetComponent<MoveScript>().speed = new Vector3(0, 0, speed);
            Timer2 = Random.Range(TimerMin1, TimerMax1);
        }




        elapsed = Time.time - start_time;
        if (elapsed >= TimerValue) //after 10 seconds
         {
            Debug.Log("Timer");
            speed += 0.5f;
            TimerMin -= 5.0f;
            TimerMax -= 5.0f;
            TimerMin1 -= 5.0f;
            TimerMax1 -= 5.0f;
            TimerValue += 10.0f;
         }
    }
}