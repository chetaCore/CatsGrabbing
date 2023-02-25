using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementColumns : PlacementGameElement
{
    private void OnEnable()
    {
        EventSet.characterOvercameDistance += Placement;
    }
    protected void Start()
    {
        _createGameElement = GetComponent<CreateGameElement>();
        _createdGameElements = _createGameElement.GetCreatedGameElement; 
    }
    protected override void Placement( int characterPosition )
    {
        var columnRandomPos = Random.Range(-3, 4);
        var columnPrecentageMovement = Random.Range(0.6f, 0.7f);


        var activeColumn = _createdGameElements.Dequeue();
        Column column = activeColumn.GetComponent<Column>();

        activeColumn.transform.position = new Vector3(characterPosition + 50f + columnRandomPos, -10, 0);
        column.place = false;
        column.precentageMovement = columnPrecentageMovement;
        column.StartMove();
        _createdGameElements.Enqueue(activeColumn);

        activeColumn = _createdGameElements.Dequeue();
        column = activeColumn.GetComponent<Column>();

        activeColumn.transform.position = new Vector3(characterPosition + 65f + columnRandomPos, 30, 0);
        column.place = true;
        column.precentageMovement = columnPrecentageMovement;
        column.StartMove();
        _createdGameElements.Enqueue(activeColumn);
    }

    private void OnDisable()
    {
        EventSet.characterOvercameDistance -= Placement;
    }
}
