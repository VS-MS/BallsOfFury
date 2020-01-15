using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControll : MonoBehaviour
{
    public static GameControll instance { get; private set; }

    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        //Проверяем, есть ли экземпляр объекта на сцене, если есть, удаляем этот экземпляр
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            //return;
        }
    }

    public void SetPauseOn()
    {
        Time.timeScale = 0;
    }

    public void SetPauseOff()
    {
        Time.timeScale = 1;
    }
}
