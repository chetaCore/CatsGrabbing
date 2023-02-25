using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    private Vector3 _startPosition;


    private void OnEnable()
    {
        EventSet.gameIsRestarted += () => transform.position = _startPosition;
    }

    private void Start()
    {
        _startPosition = transform.position;
    }


    private void OnDisable()
    {
        EventSet.gameIsRestarted -= () => transform.position = _startPosition;
    }


}

