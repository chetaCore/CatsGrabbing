using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private MeshRenderer _mesh;
    [SerializeField] private int _startHp;
    [SerializeField] private int _hP;
    [SerializeField] private float _invincibilityDuration;
    [SerializeField] private float _blinkStep;

    private Rigidbody _rigidbody;
    private int _characterDistance;
    private bool _isDamaged;
    public bool IsDamaged => _isDamaged;

    public int StartHp => _startHp;
    public int HP{ get => _hP; 
        set {
            if (_isDamaged) return;
            _hP -= value;
            _isDamaged = true;


            DOTween.Sequence().AppendInterval(_blinkStep).AppendCallback(() => ChangeMeshState()).SetLoops(Mathf.RoundToInt(_invincibilityDuration / _blinkStep));

            DOTween.Sequence().AppendInterval(_invincibilityDuration).OnComplete(() => _isDamaged = false);
            if (_hP <= 0)
            {
                EventSet.characterDead?.Invoke();
            }        
        } 
    }

    private void OnEnable()
    {
        EventSet.gameIsRestarted += () => _characterDistance = 0;
    }

    private void Start()
    {
        EventSet.characterFaced += () => HP = 1;
        EventSet.heartIsTaken += () => _hP++;
        EventSet.gameIsRestarted += () => _hP = _startHp;

    }

    private void OnDisable()
    {
        EventSet.gameIsRestarted -= () => _characterDistance = 0;
        EventSet.characterFaced -= () => HP = 1;
        EventSet.heartIsTaken -= () => _hP++;
        EventSet.gameIsRestarted -= () => _hP = _startHp;
    }
    private void Awake()
    {
        _hP = _startHp;
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
    }

    private void Update()
    {
        CheckPosition();
    }

    private void CheckPosition()
    {
        int pos = Mathf.RoundToInt(transform.position.x);

        if (_characterDistance >= pos)
            return;
        
        if (pos % 30 == 0)
        {
            _characterDistance = pos;
            EventSet.characterOvercameDistance.Invoke(pos);
        }
    }

    private void ChangeMeshState()
    {
        if (_mesh.enabled)
            _mesh.enabled = false;
        else
            _mesh.enabled = true;
    }


}
