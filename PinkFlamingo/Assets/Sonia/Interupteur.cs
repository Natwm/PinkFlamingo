using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interupteur : MonoBehaviour
{
    public bool m_State = true;

    public enum state
    {
        ON,
        OFF
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeStatus()
    {
        m_State = !m_State;
    }

    private void OnCollisionEnter(Collision collision)
    {
        m_State = !m_State;
    }
}
