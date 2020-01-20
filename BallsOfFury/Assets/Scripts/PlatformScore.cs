using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlatformScore : MonoBehaviour
{
    [Inject]
    private GameController gameController;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlayerBall")
        {
            Debug.Log(gameController);
            gameObject.SetActive(false);
        }
    }


}
