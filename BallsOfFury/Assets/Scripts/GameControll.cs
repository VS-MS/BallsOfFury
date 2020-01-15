using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IGameControll
    {
    void SetPauseOn();
    void SetPauseOff();
    bool IsPaused { get; }
    }
public class GameControll : IGameControll
{
    public bool IsPaused { get { return isPaused; } }
    public bool isPaused = false;

    public void SetPauseOn()
    {
        isPaused = true;
        Time.timeScale = 0;
    }

    public void SetPauseOff()
    {
        isPaused = false;
        Time.timeScale = 1;
    }
}
