using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour 
{
    [SerializeField]
    private GameObject mainPlatform;
    //Счетчик для набранных очков.
    public int Score;

    [Inject]
    private PlayerBall playerBall;
    [Inject]
    private CameraController cameraController;
    [Inject]
    private PlatformController platformController;

    //Флаг для определения, готовности игры к запуску.
    [HideInInspector]
    public bool IsReady = true;

    //Флаг для определиня, что игрок проиграл.
    [HideInInspector]
    public bool IsOver = false;

    private ITimeController timeController;
    [Inject]
    public void Setup(ITimeController timeController)
    {
        this.timeController = timeController;
    }

    private void Awake()
    {
        //Создаем первые платформы.
        platformController.Initialize();
    }

    private void Start()
    {
        IsReady = true;
        timeController.SetPauseOn();
        
    }

    //Запускаем игру.
    public void Play()
    {
        //Выставляем флаг направления игрока "Вверх".
        playerBall.Direction = false;
        timeController.SetPauseOff();

        //Выставляем флаг готовности.
        IsReady = false;

    }

    //Перестраиваем уровень и готовимся к запуску игры.
    public void Restart()
    {
        //Скрываем все платформы из сцены.
        platformController.DiactivateAllObj();

        //Создаем первые платформы.
        platformController.Initialize();

        //Ставим на начальное положение игрока, камеру и главную платформу.
        playerBall.transform.position = new Vector3(.5f, .4f, -.5f);
        cameraController.transform.position = new Vector3(-1.5f, 3.4f, -2.5f);
        mainPlatform.transform.position = new Vector3(0, 0, 0);

        //Выставляем флаг направления игрока "Вверх".
        playerBall.Direction = false;
        
        //Обнуляем набранные очки
        Score = 0;

        //Выставляем флаг готовности к запуску
        IsReady = true;
        //Отключаем флаг проигрыша.
        IsOver = false;
    }

    //Game Over
    public void GameIsOver()
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
            GameIsOver();
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
