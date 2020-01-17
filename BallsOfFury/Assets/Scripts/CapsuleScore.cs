using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CapsuleScore : MonoBehaviour
{
    [Inject]
    private GameController gameController;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerBall")
        {
            gameController.Score++;
            gameObject.SetActive(false);
        }
    }
}
