using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementFishPoints : PlacementGameElement
{
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

    protected override void Placement(int characterPosition)
    {
        var pointHeight = Random.Range(4, 16);
        var scatterPointPosition = Random.Range(30, 40);

        var activePonint = _createdGameElements.Dequeue();

        activePonint.transform.position = new Vector3(characterPosition + scatterPointPosition, pointHeight, 0);
        _createdGameElements.Enqueue(activePonint);

    }

    private void OnDisable()
    {
        EventSet.characterOvercameDistance -= Placement;
    }
}
