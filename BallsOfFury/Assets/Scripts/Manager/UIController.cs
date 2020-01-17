using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI score;
    [SerializeField]
    private GameObject tapToRestart;
    [SerializeField]
    private GameObject tapToStart;

    [Inject]
    private GameController gameController;

#if UNITY_EDITOR
    private void OnValidate()
    {
        score = transform.Find("Score").GetComponent<TextMeshProUGUI>();
        tapToRestart = transform.Find("TapToRestart").gameObject;
        tapToStart = transform.Find("TapToStart").gameObject;
    }
#endif

    private void Update()
    {
        //Проверяем игру на готовность и выводим надпись Tap to start
        if(gameController.IsReady)
        {
            tapToStart.SetActive(true);
        }
        else
        {
            tapToStart.SetActive(false);
        }

        //Проверяем игру на GameOver и выводим надпись Tap to restart
        if (gameController.IsOver)
        {
            tapToRestart.SetActive(true);
        }
        else
        {
            tapToRestart.SetActive(false);
        }

        score.text = "Score: " + gameController.Score.ToString();
    }
}
