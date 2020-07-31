using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlamingHell : MonoBehaviour
{
    GameObject flamingo;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 0.65f;

    public void Start()
    {
        flamingo = Resources.Load<GameObject>("Flamingo");
    }

    public void Update()
    {
        if(timeBtwSpawn <= 0)
        {
            Instantiate(flamingo, transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }

}
