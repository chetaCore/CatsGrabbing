using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    [SerializeField] private DOTweenAnimation _animation;

    private void OnEnable()
    {
        EventSet.gamePointTaken += PlayAnimation;     
    }

    private void OnDisable()
    {
        EventSet.gamePointTaken -= PlayAnimation;
    }

    private void PlayAnimation(int value)
    {

        _animation.DORestart();

        _animation.DORestartById("up");

    }
}
