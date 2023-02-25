using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioMuteButton : MonoBehaviour
{
    [SerializeField] private Sprite _activeSprite;
    [SerializeField] private Sprite _deactiveSprite;
    [SerializeField] private Image _buttonImage;
    [SerializeField] private Button _button;
    private bool _condition = true;

    private void Start()
    {
        SwitchAudio(); 
    }

    private void Awake()
    {
        _button.onClick.AddListener(SwitchAudio);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(SwitchAudio);
    }

    private void SwitchAudio()
    {
        if (_condition)
        {
            _buttonImage.sprite = _activeSprite;
            AudioListener.pause = false;
            _condition = false;
        }
        else
        {
            _buttonImage.sprite = _deactiveSprite;
            AudioListener.pause = true;
            _condition = true; 
        }
    }

}
