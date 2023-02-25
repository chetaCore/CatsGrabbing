using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _character;
    [SerializeField] private TMP_Text _countdownText;

    [SerializeField] private GameObject _defeatMenu;


    private Vector3 _characterStartPosition; 
 


    private void Awake()
    {
        EventSet.gameIsStarted += () => StartCoroutine(CountDown());
        EventSet.gameIsRestarted += RestartGame;
<<<<<<< HEAD
        EventSet.characterFaced += () => StartCoroutine(OpenDefeatMenu());
=======
        EventSet.characterDead += () => StartCoroutine(OpenDefeatMenu());
    }

    private void OnDisable()
    {
        EventSet.gameIsStarted -= () => StartCoroutine(CountDown());
        EventSet.gameIsRestarted -= RestartGame;
        EventSet.characterDead -= () => StartCoroutine(OpenDefeatMenu());

>>>>>>> master
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        _characterStartPosition = _character.transform.position;
    }

    private IEnumerator CountDown()
    {
        _countdownText.gameObject.SetActive(true);

        _character.GetComponent<Rigidbody>().isKinematic = true;

        int value = int.Parse(_countdownText.text);

        while (value > -1)
        {
            _countdownText.text = value--.ToString();  
            yield return new WaitForSeconds(0.7f);
        }

        _countdownText.gameObject.SetActive(false);

        _character.GetComponent<Rigidbody>().isKinematic = false;

        _countdownText.text = "3";

        yield return null;
    }

    private IEnumerator OpenDefeatMenu()
    {
        yield return new WaitForSeconds(0.8f);
        _character.SetActive(false);
        _defeatMenu.SetActive(true);
        
    }

    private void RestartGame()
    {
        _character.transform.position = _characterStartPosition;
        _character.SetActive(true);
        StartCoroutine(CountDown());  
    }

<<<<<<< HEAD
    private void OnDisable()
    {
        EventSet.gameIsStarted -= () => StartCoroutine(CountDown());
        EventSet.gameIsRestarted -= RestartGame;
        EventSet.characterFaced -= () => StartCoroutine(OpenDefeatMenu());
    }
=======
  
>>>>>>> master

}
