using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    private void Awake()
    {
        _startButton.onClick.AddListener(StartGame);
    }
    private void StartGame()
    {
        EventSet.gameIsStarted?.Invoke();
        gameObject.SetActive(false);
        DOTween.Sequence().AppendInterval(0.2f).OnComplete(() => gameObject.SetActive(false));
        
    }
    private void OnDestroy()
    {
        _startButton.onClick.RemoveListener(StartGame);

    }
}
