using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePoints : MonoBehaviour
{
    private TMP_Text _pointsText;
    private int _allPoints = 0;

<<<<<<< HEAD
    private void OnEnable()
    {
        EventSet.gamePointTaken += ChangePoints;
    }
    private void Start()
    {
        _pointsText = GetComponent<TMP_Text>();
=======
    

    private void Awake()
    {
        _allPoints = BaseSaver.GetCoinsSaves;
        EventSet.characterDead += () => BaseSaver.UpdateCoinsSaves(_allPoints);
        EventSet.gamePointTaken += ChangePoints;
    }

    private void OnDestroy()
    {
        EventSet.characterDead -= () => BaseSaver.UpdateCoinsSaves(_allPoints);
        EventSet.gamePointTaken -= ChangePoints;
    }

    private void Start()
    {
         _pointsText = GetComponent<TMP_Text>();
        _pointsText.text = _allPoints.ToString();
>>>>>>> master
    }

    private void ChangePoints(int addedPoints)
    {
        _allPoints += addedPoints;
        _pointsText.text = _allPoints.ToString();
    }
<<<<<<< HEAD
    private void OnDisable()
    {
        EventSet.gamePointTaken -= ChangePoints;
    }
=======
>>>>>>> master
}
