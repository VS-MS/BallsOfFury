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
        platformController.SetNewPositionObj(parentObj);
        //перетаскиваем панель после окончания анимации на новое место
    }
    private void Awake()
    {
        platformAnimator = GetComponent<Animator>();
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerBall")
        {
            platformAnimator.SetBool("IsTop", false);
        }
    }
}
