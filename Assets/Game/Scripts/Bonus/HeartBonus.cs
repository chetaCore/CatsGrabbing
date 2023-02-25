using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeartBonus : MonoBehaviour
{
    [SerializeField] private int _numberToTaken;
    [SerializeField] private DOTweenAnimation _increaseSizeTween;
    [SerializeField] private GameObject _box;
    [SerializeField] private ParticleSystem _confetiParticle;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private TMP_Text _progressText;

    private int _curentNumberToTaken;
    private bool _isUsed;
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.parent.localPosition;
        _curentNumberToTaken = _numberToTaken;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.TryGetComponent(out Column column))
        {
            transform.position = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z);
        }

        if (!other.TryGetComponent(out Character character)) return;
        if (_isUsed) return;

        TakedBonuses();
    }

    private void ReturnOriginalState()
    {
        transform.position = _startPosition;
        _box.SetActive(true);
        _isUsed = false;
    }

    private void TakedBonuses()
    {
        _audio.Play();

        _increaseSizeTween.DORestartById("increase");
        _curentNumberToTaken--;
        BonusProgress();
        if (_curentNumberToTaken == 0)
        {
            _isUsed = true;
            _box.SetActive(false);
            _confetiParticle.Play();
            DOTween.Sequence().AppendInterval(1f).OnComplete(() =>
            {
                BonusProgress();
                ReturnOriginalState();
            });
            _curentNumberToTaken = _numberToTaken;
            
            EventSet.heartIsTaken?.Invoke();
        }
    }

    private void BonusProgress()
    {
        _progressText.text = _numberToTaken - _curentNumberToTaken + "/" + _numberToTaken;
    }
}
