using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour 
{
    [SerializeField]
    private GameObject mainPlatform;
    [Inject]
    private PlayerBall playerBall;
    [Inject]
    private CameraController cameraController;
    [Inject]
    private PlatformController platformController;
    [Inject]
    private ObjectPooler objectPooler;

    public int Score;

    //Флаг для определения, готовности игры к запуску.
    [HideInInspector]
    public bool IsReady = true;
    //Флаг для определиня, что игрок проиграл.
    public bool IsOver;

    private ITimeController timeController;
    [Inject]
    public void Setup(ITimeController timeController)
    {
        this.timeController = timeController;
    }

    private void Awake()
    {
        platformController.Initialize();
    }
    private void Start()
    {
        IsReady = true;
        timeController.SetPauseOn();
        
    }
    //Запускаем игру
    public void Play()
    {
        //Запустить создание платформ.
        //Выключить паузу.
        playerBall.Direction = false;
        timeController.SetPauseOff();
        IsReady = false;

    }

    //Перестраиваем уровень и готовимся к запуску игры.
    public void Restart()
    {
        objectPooler.DiactivateAllItem();
        //Ставим на начальное положение игрока, камеру и платформы.
        mainPlatform.transform.position = new Vector3(0, 0, 0);
        playerBall.transform.position = new Vector3(.5f, .4f, -.5f);
        //Выставляем флаг направления игрока "Вверх".
        playerBall.Direction = false;
        cameraController.transform.position = new Vector3(-1.5f, 3.4f, -2.5f);

        Score = 0;

        //Выставляем флаг готовности к запуску
        IsReady = true;
        IsOver = false;
    }

    //Game Over
    public void GameIsEnd()
    {
        IsReady = false;
        IsOver = true;
        //Выставить время на паузу.
        timeController.SetPauseOn();
    }

    private void Update()
    {
        //Если игрок упал - запускаем конец игры.
        if (playerBall.transform.position.y < -0.5f)
        {
            GameIsEnd();
            //Если нажать ЛКМ - запускаем перезапуск уровня.
            if (Input.GetMouseButtonDown(0))
            {
                Restart();
            }
        }
        //Если уровень готов и игрок нажал ЛКМ - запускаем игру.
        else if (Input.GetMouseButtonDown(0) && IsReady)
        {
            Play();
        }

    }
}
