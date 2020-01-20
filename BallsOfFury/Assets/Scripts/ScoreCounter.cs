using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ScoreCounter : MonoBehaviour
{
    [Inject]
    private GameController gameController;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Capsule")
        {
            gameController.Score++;
            other.gameObject.SetActive(false);
        }
    }
}
