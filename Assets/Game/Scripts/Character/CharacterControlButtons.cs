using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControlButtons : MonoBehaviour
{
    [SerializeField] private Rigidbody _characterRigidbody;
    [SerializeField] private float _powerPushingForward = 10;

    private Button _controllButton;

    private void Awake()
    {
       _controllButton = GetComponent<Button>();
        _controllButton.onClick.AddListener(Move);
    }

    private void OnEnable()
    {
        EventSet.characterOvercameDistance += AddMovePower;
    }

    private void AddMovePower(int characterPosition)
    {

        if (_powerPushingForward > 0)
            _powerPushingForward += 0.01f;
        else
            _powerPushingForward -= 0.01f;
    }

    private void Move()
    {
        _characterRigidbody.AddForce(new Vector3(_powerPushingForward, 10f, 0), ForceMode.Impulse);
    }

    private void OnDestroy()
    {
        EventSet.characterOvercameDistance -= AddMovePower;
    }
}
