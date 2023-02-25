using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private Sprite _activeSprite;
    [SerializeField] private Sprite _deactiveSprite;
    [SerializeField] private Image _buttonImage;
    [SerializeField] private Button _button;
    private bool _condition;

    private void Awake()
    {
        _button.onClick.AddListener(SwitchTimeScale);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(SwitchTimeScale);
    }


    private void SwitchTimeScale()
    {
        if (_condition)
        {
            _buttonImage.sprite = _activeSprite;
            Time.timeScale = 1;
            _condition = false;
        }
        else
        {
            _buttonImage.sprite = _deactiveSprite;
            Time.timeScale = 0;
            _condition = true;
        }
    }
}
