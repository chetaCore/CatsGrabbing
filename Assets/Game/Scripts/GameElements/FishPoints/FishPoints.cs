using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPoints : MonoBehaviour
{


    [SerializeField] private int _pointValue = 1;
    [SerializeField] private ParticleSystem _takeParticle;
    [SerializeField] private ParticleSystem _glowParticle;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private AudioSource _audio;


    private Vector3 _startPosition;
    private bool isUsed;
    private bool _isUsed;


    private void Start()
    {
        _startPosition = transform.parent.localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Character character))
        {
            if (isUsed) return;
            if (_isUsed) return;

            EventSet.gamePointTaken.Invoke(_pointValue);
            _glowParticle.gameObject.SetActive(false);
            _audio.Play();
            _takeParticle.Play();

            isUsed = true;
            _isUsed = true;

            _meshRenderer.enabled = false;

            DOTween.Sequence().AppendInterval(1f).OnComplete(ReturnOriginalState);       

        }

        if (other.gameObject.TryGetComponent(out Column column))
        {
            transform.position = new Vector3(transform.position.x + 4, transform.position.y, transform.position.z);
            transform.position = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z);
        }
    }

    private void ReturnOriginalState()
    {
        transform.position = _startPosition;
        _meshRenderer.enabled = true;
        isUsed = false;
        _isUsed = false;
        _glowParticle.gameObject.SetActive(true);
    }
}
