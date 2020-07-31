using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlamingHell : MonoBehaviour
{
    GameObject flamingo;
    public float SpawnInterval;
    float timer;
    public void Start()
    {
        flamingo = Resources.Load<GameObject>("Flamingo");
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer > SpawnInterval)
        {
            GameObject spFlam = Instantiate(flamingo);
            spFlam.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
            timer = 0;
        }
    }

}
