using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RearBarrier : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private int _yPos;
    [SerializeField] private int _zPos;
    private Vector3 _startPosition;

    private bool _gameIsStarted = false;
    private void OnEnable()
    {
        EventSet.gameIsStarted += () => _gameIsStarted = true;
<<<<<<< HEAD
        EventSet.characterFaced += () => _gameIsStarted = false;
=======
        EventSet.characterDead += () => _gameIsStarted = false;
>>>>>>> master
        EventSet.gameIsRestarted += () => _gameIsStarted = true;
        EventSet.gameIsRestarted += () => transform.position = _startPosition;
    }

    private void Start()
    {
        _startPosition = transform.position;   
    }

    void Update()
    {
        Movement();
    }


    private void Movement()
    {
        if (!_gameIsStarted) return;
<<<<<<< HEAD
=======
        if (Time.timeScale == 0) return;
>>>>>>> master
        transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z);
        if (transform.position.x > _character.transform.position.x - 60) return;
        transform.position = new Vector3(_character.transform.position.x - 60, _yPos, _zPos);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Character character))
        {
<<<<<<< HEAD
            EventSet.characterFaced.Invoke(); 
=======
            EventSet.characterFaced.Invoke();
>>>>>>> master
        }
    }

    private void OnDisable()
    {
        EventSet.gameIsStarted -= () => _gameIsStarted = true;
<<<<<<< HEAD
        EventSet.characterFaced -= () => _gameIsStarted = false;
=======
        EventSet.characterDead -= () => _gameIsStarted = false;
>>>>>>> master
        EventSet.gameIsRestarted -= () => _gameIsStarted = true;
        EventSet.gameIsRestarted -= () => transform.position = _startPosition;
    }
}
