using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private int _yPos = 10;
    [SerializeField] private int _zPos = -20;

    void Update()
    {
        Movement();   
    }


    private void Movement()
    {
        transform.position = new Vector3(_character.transform.position.x, _yPos, _zPos);
    }
}
