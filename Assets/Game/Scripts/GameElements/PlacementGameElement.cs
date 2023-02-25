using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlacementGameElement : MonoBehaviour
{
    protected CreateGameElement _createGameElement;

    protected Queue<GameObject> _createdGameElements;

    
    protected virtual void Placement(int characterPosition)
    {
        print("Placemented");
    }

}
