<<<<<<< HEAD
=======
using DG.Tweening;
>>>>>>> master
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    [SerializeField] private int _heightPlayerSpace;
<<<<<<< HEAD
    
=======
    [SerializeField] private AudioPlayer _audioPlayer;
>>>>>>> master
    private float _columnSpeed = 0.005f;
    private float _columnPitch = 0.03f;
    private Vector3 _startPosition;

    public bool place;
    public float precentageMovement;

    private IEnumerator _moveCoroutine;

    private void OnEnable()
    {
        EventSet.gameIsRestarted += () => transform.position = _startPosition;
    }

    private void Start()
    {
        _startPosition = transform.position;
        _moveCoroutine = Movement();
    }
    public void StartMove()
    {
        StopCoroutine(_moveCoroutine);
        StartCoroutine(_moveCoroutine);
    }

    IEnumerator Movement()
    {
        if (place)
            transform.Rotate(0f, 0.0f, 180f, Space.Self);

        while (true)
        {
            if (place)
            {
<<<<<<< HEAD
                
                while (Mathf.Round(transform.position.y) - transform.localScale.y / 2 != Mathf.Round(_heightPlayerSpace - _heightPlayerSpace * precentageMovement))
                {

=======

                while (Mathf.Round(transform.position.y) - transform.localScale.y / 2 != Mathf.Round(_heightPlayerSpace - _heightPlayerSpace * precentageMovement))
                {
>>>>>>> master
                    transform.position += -Vector3.up * _columnPitch;
                    yield return new WaitForSeconds(_columnSpeed);
                }

<<<<<<< HEAD
=======

>>>>>>> master
                while (Mathf.Round(transform.position.y) - transform.localScale.y / 2 != _heightPlayerSpace)
                {
                    transform.position += Vector3.up * _columnPitch;
                    yield return new WaitForSeconds(_columnSpeed);
                }

            }
            else
            {
                while (Mathf.Round(transform.position.y) + transform.localScale.y / 2 != 0)
                {
                    transform.position += -Vector3.up * _columnPitch;
                    yield return new WaitForSeconds(_columnSpeed);
                }

                while (Mathf.Round(transform.position.y) + transform.localScale.y / 2 != Mathf.Round(_heightPlayerSpace * precentageMovement))
                {
                    transform.position += Vector3.up * _columnPitch;
                    yield return new WaitForSeconds(_columnSpeed);
                }

            }
            yield return new WaitForSeconds(1f);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Character character))
        {
            EventSet.characterFaced.Invoke();
        }
    }

    private void OnDisable()
    {
        EventSet.gameIsRestarted -= () => transform.position = _startPosition;
    }
}
