using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawning : MonoBehaviour
{
    public GameObject testObj;
    GameObject SpawnedtestObj;
    public float TimerMin;
    public float TimerMax;
    float Timer;

    void Start()
    {
        Timer = Random.Range(TimerMin, TimerMax);

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
            SpawnedtestObj = Instantiate(testObj) as GameObject;
            SpawnedtestObj.transform.position = new Vector2(Random.Range(-8.0f, 8.0f), 12.0f);
            Timer = Random.Range(TimerMin, TimerMax);
        }

    }
}