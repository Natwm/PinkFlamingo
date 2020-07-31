using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamingoManager : MonoBehaviour
{
    public float FlamingoSpeed;
    public GameObject Target;
    public float pauseTime;
    AudioSource Sqwek;
    public float wait = 3f;

    public GameObject can;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        Sqwek = GetComponent<AudioSource>();
        can.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MoveMenacingly();
    }

    public void MoveMenacingly()
    {
        wait = wait - Time.deltaTime;

        if (wait < 0)
        {
            transform.LookAt(Target.transform, Vector3.down);

            transform.Translate(Vector3.forward * FlamingoSpeed);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Grab")
        {
            StartCoroutine(CollisionStop());
            Destroy(other.gameObject);
        }

        if (other.tag == "Player")
        {
            can.SetActive(true);
        }
    }

    public IEnumerator CollisionStop()
    {
        float oldFlamSpeed = FlamingoSpeed;
        FlamingoSpeed = 0;
        Sqwek.Play();
        yield return new WaitForSeconds(pauseTime);
        Debug.Log("hey");
        FlamingoSpeed = oldFlamSpeed;
    }


}
