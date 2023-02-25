using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnsMover : MonoBehaviour
{
    private Sequence _seq;
    private Vector3 _startPositon;

    private bool _placement;
    public bool Placement { get => _placement; set => _placement = value; }


    private void Start()
    {
        _startPositon = transform.position;
        _seq = DOTween.Sequence();
    }

    public void Move(bool placement, float maxMovementValue)
    {
        if (placement)
        {
            transform.Rotate(0f, 0.0f, 180f, Space.Self);
            _seq.Append(transform.DOMoveY(_startPositon.y - maxMovementValue, 10, false).SetEase(Ease.Linear));
            _seq.Append(transform.DOMoveY(_startPositon.y, 10, false).SetEase(Ease.Linear));
            _seq.SetLoops(-1);
        } else
        {
            _seq.Append(transform.DOMoveY(_startPositon.y + maxMovementValue, 10, false).SetEase(Ease.Linear));
            _seq.Append(transform.DOMoveY(_startPositon.y, 10, false).SetEase(Ease.Linear));
            _seq.SetLoops(-1);
        }
        
    }


}
