using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlatformAnimation : MonoBehaviour
{
    [SerializeField]
    private GameObject parentObj;
    private Animator platformAnimator;
    [Inject]
    private PlatformController platformController;

    public void SetNewPosition()
    {
        platformAnimator.SetBool("IsTop", true);
        //перетаскиваем панель после окончания анимации на новое место
        platformController.SetNewPositionObj(parentObj);
        
    }
    private void Awake()
    {
        platformAnimator = GetComponent<Animator>();
    }
    private void OnCollisionExit(Collision collision)
    {
        //Если игрок покинул платформ, включаем триггер анимации падения.
        if (collision.gameObject.tag == "PlayerBall")
        {
            platformAnimator.SetBool("IsTop", false);
        }
    }
}
