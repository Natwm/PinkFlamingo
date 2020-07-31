using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRefs : MonoBehaviour
{
    Flamingo_CharaController chara;
    public void Start()
    {
        chara = GameObject.FindObjectOfType<Flamingo_CharaController>();
        chara.defaite = GameObject.Find("Defaite");
        chara.rejouer = GameObject.Find("R");
        chara.victoire = GameObject.Find("Victoire");
        chara.Animator = transform.GetChild(0).GetChild(0).GetComponent<Animator>();
    }
}
