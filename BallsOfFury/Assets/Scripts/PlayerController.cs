﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [Inject]
    private PlayerBall player;
    [Inject]
    private GameController gameController;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameController.IsReady)
        {
            player.Direction = !player.Direction;
        }
            
    }

}
