using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratulatoryCanvas : MonoBehaviour
{

    private void Awake()
    {
        if (BaseSaver.GetCongratulatorySaves == 1)
        {
            gameObject.SetActive(false);
        }
    }


    public void DeactivateCanvas()
    {
        BaseSaver.UpdateCongratulatorySaves();
        gameObject.SetActive(false);
    } 
}
