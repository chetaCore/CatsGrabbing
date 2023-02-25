using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    [SerializeField] private UiHeart _heart;
    [SerializeField] private Character _character;
    private Stack<UiHeart> _heartList = new();

    private void OnEnable()
    {
        EventSet.characterFaced += RemoveHeart;
        EventSet.heartIsTaken += () => AddHeart(1);
        EventSet.gameIsRestarted += () =>
        {
            while (_heartList.Count != 0)
                RemoveHeart();
            AddHeart(_character.StartHp);

        };
    }

    private void OnDisable()
    {
        EventSet.characterFaced -= RemoveHeart;
        EventSet.heartIsTaken -= () => AddHeart(1);
        EventSet.gameIsRestarted -= () =>
        {
            while (_heartList.Count != 0)
                RemoveHeart();
            AddHeart(_character.StartHp);

        };

    }

    private void Start()
    {
        AddHeart(_character.StartHp);
    }



    private void AddHeart(int count)
    {
        UiHeart createdHeart;
        for (int i = 0; i < count; i++)
        {
            createdHeart = Instantiate(_heart, transform.position, Quaternion.identity, transform);
            _heartList.Push(createdHeart);
            createdHeart.StartAddAnimation();
        }
       
    }

    private void RemoveHeart()
    {
        UiHeart deletedHeart;
        if (!_character.IsDamaged)
            if (_heartList.Count != 0)
            {
                deletedHeart = _heartList.Pop();
                deletedHeart.StartRemoveAnimation();
                Destroy(deletedHeart.gameObject, 0.5f);
            }
                
    }
}
