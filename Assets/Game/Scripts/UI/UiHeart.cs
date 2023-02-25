using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHeart : MonoBehaviour
{
    [SerializeField] private DOTweenAnimation _removeAnimation;
    [SerializeField] private DOTweenAnimation _addAnimation;

    public void StartRemoveAnimation()
    {
        _removeAnimation.DORestartById("remove");
    } 

    public void StartAddAnimation()
    {
        _addAnimation.DORestartById("add");
    }
}
