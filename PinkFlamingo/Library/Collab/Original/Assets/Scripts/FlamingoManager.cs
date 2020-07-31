using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamingoManager : MonoBehaviour
{
    public float FlamingoSpeed;
    public GameObject Target;
    public float pauseTime;
    AudioSource Sqwek;
    public AudioSource Gouglou;
    public float distance;
    public float ClmDist;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        Sqwek = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveMenacingly();
        distance = Vector3.Distance(transform.position, Target.transform.position);
        float ClmDist = Mathf.InverseLerp(0, 1, distance);
        
        
    }

    public void MoveMenacingly()
    {
        transform.LookAt(Target.transform,Vector3.down);
        
        transform.Translate(Vector3.forward * FlamingoSpeed);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FlamingoObstacle")
        {
            StartCoroutine(CollisionStop());
            Destroy(other.gameObject);
        }
    }

    IEnumerator CollisionStop()
    {
        float oldFlamSpeed = FlamingoSpeed;
        FlamingoSpeed = 0;
        Sqwek.Play();
        yield return new WaitForSeconds(pauseTime);
        FlamingoSpeed = oldFlamSpeed;
    }


}
