using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefeatMenu : MonoBehaviour
{
    [SerializeField] private Button _restartButton;

    private void Awake()
    {
        _restartButton.onClick.AddListener(() => EventSet.gameIsRestarted.Invoke());
        _restartButton.onClick.AddListener(() => gameObject.SetActive(false));
    }

}
