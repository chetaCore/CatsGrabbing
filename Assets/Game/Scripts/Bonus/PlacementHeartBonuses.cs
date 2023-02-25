using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementHeartBonuses : PlacementBonuses
{   
    [Range(0,1)]
    [SerializeField] private float _spawnChanse;

    protected new void Start()
    {
        _createGameElement = GetComponent<CreateGameElement>();
        _createdGameElements = _createGameElement.GetCreatedGameElement;
    }

    protected override void Placement(int characterPosition)
    {

        var chanse = Random.Range(0f, 1f);

        if (chanse > _spawnChanse) return;

        var pointHeight = Random.Range(4, 16);
        var scatterPointPosition = Random.Range(_deploymentDespersion, _deploymentRange + _deploymentDespersion);

        var activePonint = _createdGameElements.Dequeue();

        activePonint.transform.position = new Vector3(characterPosition + scatterPointPosition, pointHeight, 0);
        _createdGameElements.Enqueue(activePonint);

    }
}
