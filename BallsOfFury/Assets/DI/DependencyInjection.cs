using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DependencyInjection : MonoBehaviour
{
    private IGameControll gameController;
    [Inject]
    public void Setup(IGameControll gameController)
    {
        this.gameController = gameController;
    }

    private void Start()
    {
        //gameController.SetPauseOn();
        Debug.Log(gameController.IsPaused);
    }

}