using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDiedParticle : MonoBehaviour
{
    [SerializeField] ParticleSystem _diedParticle;
    [SerializeField] AudioSource _audio;
<<<<<<< HEAD

    private void OnEnable()
    {
        EventSet.characterFaced += () => _diedParticle.Play();
        EventSet.characterFaced += () => _audio.Play();
=======
    [SerializeField] Character _character;

    private void OnEnable()
    {

        EventSet.characterFaced += () => 
        {
            if (_character.IsDamaged) return;
            Handheld.Vibrate();
            _diedParticle.Play();
        };

        EventSet.characterFaced += () =>
        {
            if (_character.IsDamaged) return;
            Handheld.Vibrate();
            _audio.Play();
        };
>>>>>>> master
    }

    private void OnDisable()
    {
<<<<<<< HEAD
        EventSet.characterFaced -= () => _diedParticle.Play();
        EventSet.characterFaced -= () => _audio.Play();

=======
        EventSet.characterFaced -= () =>
        {
            if (_character.IsDamaged) return;
            Handheld.Vibrate();
            _diedParticle.Play();
        };

        EventSet.characterFaced -= () =>
        {
            if (_character.IsDamaged) return;
            Handheld.Vibrate();
            _audio.Play();
        };
>>>>>>> master
    }
}
