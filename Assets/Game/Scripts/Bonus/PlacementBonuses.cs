using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementBonuses : MonoBehaviour
{
    protected CreateGameElement _createGameElement;
    protected Queue<GameObject> _createdGameElements;

    [SerializeField] protected int _deploymentRange;
    [SerializeField] protected int _deploymentDespersion;


    private void OnEnable()
    {
        EventSet.characterOvercameDistance += Placement;
    }

    protected void Start()
    {
        _createGameElement = GetComponent<CreateGameElement>();
        _createdGameElements = _createGameElement.GetCreatedGameElement;
        Placement(0);
    }

    protected virtual void Placement(int characterPosition)
    {
        var pointHeight = Random.Range(4, 16);
        var scatterPointPosition = Random.Range(_deploymentDespersion, _deploymentRange + _deploymentDespersion);

        var activePonint = _createdGameElements.Dequeue();

        activePonint.transform.position = new Vector3(characterPosition + scatterPointPosition, pointHeight, 0);
        _createdGameElements.Enqueue(activePonint);

    }

    private void OnDisable()
    {
        EventSet.characterOvercameDistance -= Placement;
    }
}
