using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviours : MonoBehaviour
{
    // Start is called before the first frame update
    public Color open;
    public Color close;

    public Interupteur button;
    public Transform endPos;
    public Vector3 startPos;
    void Start()
    {
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (button.m_State == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos.position, 0.25f);
            GetComponent<Renderer>().material.color = open;
        }
        if (button.m_State == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, 0.25f);
            GetComponent<Renderer>().material.color = close;
        }
    }
}