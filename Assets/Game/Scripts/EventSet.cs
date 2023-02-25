using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSet : MonoBehaviour
{
    public static Action<int> characterOvercameDistance;
    public static Action characterFaced;
    public static Action gameIsStarted;
    public static Action gameIsRestarted;
    public static Action<int> gamePointTaken;
    public static Action characterDead;
    public static Action heartIsTaken;
    
}
