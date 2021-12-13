using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float PlayerMoveSpeed = 1;
    public float PlayerMoveAcceleration = 1;
    public float PlayerJumpSpeed = 1;

    public static float playerMoveSpeed;
    public static float playerMoveAcceleration;
    public static float playerJumpSpeed;
    void Awake()
    {

    }
    void FixedUpdate()
    {
        playerJumpSpeed = PlayerJumpSpeed;
        playerMoveAcceleration = PlayerMoveAcceleration;
        playerMoveSpeed = PlayerMoveSpeed;
    }
}
