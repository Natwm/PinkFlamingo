using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamingo_CharaController : MonoBehaviour
{
    CharacterController FlamingoChara;
    public float speed;
    GameObject Player;
    Vector3 moveVector;
    public float pauseTime;
    public AudioSource Sqwek;
    public AudioSource Loop;
    public Animator Animator;
    float distance;
    public float clampedDist;
    public Vector2 minMaxDist;
    GameObject psSystem;

    public GameObject defaite;
    public GameObject victoire;
    public GameObject rejouer;

    public float wait = 3f;
    public float SphereRadius;
    // Start is called before the first frame update
    void Start()
    {
        FlamingoChara = GetComponent<CharacterController>();
        Player = GameObject.Find("Player");
        defaite.SetActive(false);
        victoire.SetActive(false);
        rejouer.SetActive(false);
        psSystem = Resources.Load("FeatherExplosion") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        wait = wait - Time.deltaTime;
        if (wait < 0)
        {
            transform.LookAt(Player.transform, Vector3.up);
            moveVector = (Player.transform.position - transform.position);
            FlamingoChara.Move(moveVector * speed);
            distance = Vector3.Distance(transform.position, Player.transform.position);
            clampedDist = Mathf.Clamp01(distance / minMaxDist.y);
            Loop.volume = 1 - clampedDist;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Grab")
        {
            //GameObject[] allGrabbed = Physics.OverlapSphere

            StartCoroutine(CollisionStop());
            GameObject psObj = Instantiate(psSystem);
            psObj.transform.SetPositionAndRotation(other.gameObject.transform.position,Quaternion.identity);
            Destroy(other.gameObject);

        }

        if (other.tag == "Player")
        {
            defaite.SetActive(true);
            rejouer.SetActive(true);
        }
    }

    public IEnumerator CollisionStop()
    {

        float oldFlamSpeed = speed;
        speed = 0;
        Animator.Play("Hit",0);
        Sqwek.Play();
        yield return new WaitForSeconds(pauseTime);
        
        speed = oldFlamSpeed;
    }
}
