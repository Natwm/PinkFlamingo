using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouloirGen : MonoBehaviour
{
    public GameObject[] AllCouloirs;
    public List<GameObject> nextCouloirs;
    // Start is called before the first frame update
    void Start()
    {
        AllCouloirs = Resources.LoadAll<GameObject>("Couloirs");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Declenchement


}
