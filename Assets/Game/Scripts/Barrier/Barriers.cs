using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barriers : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Character character))
        {
            EventSet.characterFaced.Invoke();
        }
    }
}
<<<<<<< HEAD
=======
    
>>>>>>> master
