using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePoints : MonoBehaviour
{
    private TMP_Text _pointsText;
    private int _allPoints = 0;

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
    }

    private void ChangePoints(int addedPoints)
    {
        _allPoints += addedPoints;
        _pointsText.text = _allPoints.ToString();
    }
}
