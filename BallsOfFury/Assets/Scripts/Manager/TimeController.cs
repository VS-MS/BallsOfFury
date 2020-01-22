using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITimeController
{
    void SetPauseOn();
    void SetPauseOff();
    bool IsPaused { get; set; }
}

public class TimeController : ITimeController
{
    //По этой переменной будем определять паузу.
    public bool IsPaused { get { return isPaused; } set { IsPaused = value; } }
    private bool isPaused = true;

    public void SetPauseOn()
    {
        Time.timeScale = 0;
        isPaused = true;
    }

    public void SetPauseOff()
    {
        Time.timeScale = 1;
        isPaused = false;
    }
}
