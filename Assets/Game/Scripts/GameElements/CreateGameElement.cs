using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGameElement : MonoBehaviour
{
    [SerializeField] private List<GameObject> _gameElementPrefab;
    private Queue<GameObject> _createdGameElement = new();
    public Queue<GameObject> GetCreatedGameElement => _createdGameElement;
    private List<GameObject> _createGameElementList = new();

    [SerializeField] private int _countGameElement;
    [SerializeField] private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = transform.position;
        Create();
    }

    private void OnEnable()
    {
<<<<<<< HEAD
        EventSet.characterFaced += () => DOTween.Sequence().AppendInterval(1f).OnComplete(ZeroingPosition);
=======
        EventSet.characterDead += () => DOTween.Sequence().AppendInterval(1f).OnComplete(ZeroingPosition);
>>>>>>> master
    }

    private void OnDisable()
    {
<<<<<<< HEAD
        EventSet.characterFaced -= () => DOTween.Sequence().AppendInterval(1f).OnComplete(ZeroingPosition);
=======
        EventSet.characterDead -= () => DOTween.Sequence().AppendInterval(1f).OnComplete(ZeroingPosition);
>>>>>>> master
    }

    private void ZeroingPosition()
    {

        foreach (var element in _createGameElementList)
        {
           element.transform.position = _startPosition;
        }
    }

    private void Create()
    {
        GameObject createObject = new();

        for (int i = 0; i < _countGameElement; i++)
        {
            createObject = Instantiate(_gameElementPrefab[Random.Range(0, _gameElementPrefab.Count)], transform.position, Quaternion.identity, transform);
           _createdGameElement.Enqueue(createObject);
            _createGameElementList.Add(createObject);

        }
    }
}
