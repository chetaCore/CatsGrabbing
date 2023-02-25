using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private List<AudioSource> _audioList;

    private Sequence _seq;

    private void Start()
    {
        _seq = DOTween.Sequence();
        _seq.AppendInterval(3f);
        _seq.AppendCallback(SelectRandomAudio);
        _seq.SetLoops(-1);
    }

    public void SelectRandomAudio()
    {
        _audioList[Random.Range(0, _audioList.Count)].Play();
    }

}
