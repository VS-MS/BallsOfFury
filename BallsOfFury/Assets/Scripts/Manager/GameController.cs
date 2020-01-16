using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour 
{
    
    //Флаг для опредиления, готовности игры к запуску.
    public bool IsReady;
    private ITimeController timeController;
    [Inject]
    public void Setup(ITimeController timeController)
    {
        this.timeController = timeController;
    }
    public void Play()
    {
        //Выключитьпаузу.
        timeController.SetPauseOff();
        Debug.Log(timeController.IsPaused);
        //Запустить создание платформ.
    }

    public void Restart()
    {
        //Выставить шар на начальную точку и выставить первые две платформы и главную платформу.
        //Выставить время на паузу.
        timeController.SetPauseOn();
        
    }
}
