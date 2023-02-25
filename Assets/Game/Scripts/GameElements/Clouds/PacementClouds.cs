using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacementClouds : PlacementGameElement
{

    [SerializeField] private GameObject[] _startElemnts;
    private int _curentClouds;

    private void OnEnable()
    {
        EventSet.characterOvercameDistance += Placement;
        EventSet.gameIsRestarted += () => _curentClouds = 0;
        EventSet.gameIsRestarted += () => Placement(0);
    }

    private void OnDisable()
    {
        EventSet.characterOvercameDistance -= Placement;
        EventSet.gameIsRestarted -= () => _curentClouds = 0;
        EventSet.gameIsRestarted -= () => Placement(0);
    }

    protected void Start()
    {
        _createGameElement = GetComponent<CreateGameElement>();
        _createdGameElements = _createGameElement.GetCreatedGameElement;
        _startElemnts =_createdGameElements.ToArray();

        Placement(0);
    }

    protected override void Placement(int characterPosition)
    {
        if (characterPosition % 90 != 0) return;


        var activeClouds = _startElemnts[_curentClouds];
        _curentClouds++;
        activeClouds.transform.position = new Vector3(characterPosition + 40, 0, 0);
        _createdGameElements.Enqueue(activeClouds);


        activeClouds = _startElemnts[_curentClouds];
        _curentClouds++;
        activeClouds.transform.position = new Vector3(characterPosition + 40, 20, 0);
        _createdGameElements.Enqueue(activeClouds);
        if (_curentClouds == 4)
            _curentClouds = 0;
    }









}

