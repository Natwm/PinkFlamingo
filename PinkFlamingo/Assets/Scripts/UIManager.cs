using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text winField;
    [SerializeField] private Text restartField;

    [SerializeField] private Color winColor;
    [SerializeField] private Color loseColor;


    public void VictoryFieldUpdate(string info)
    {
        Debug.Log(info);
        winField.text = info;
        restartField.gameObject.SetActive(true);
        if (info == "Victoire")
        {
            winField.color = winColor;
        }else
        {
            winField.color = loseColor;
        }
    }
}
