using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerBall player;

    private void Start()
    {
        player = FindObjectOfType<PlayerBall>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            player.Direction = !player.Direction;
        }
            
    }

}
