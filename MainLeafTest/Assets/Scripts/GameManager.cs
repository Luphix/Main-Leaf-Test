using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float PlayerMoveSpeed = 1;
    public float PlayerMoveAcceleration = 1;
    public float PlayerJumpSpeed = 1;
    [Range(0, 2)] public float EnemiesMoveSpeed = 1;
    public Color[] CoinColorByValue;

    void Awake()
    {
        if (GameObject.FindWithTag("Manager") && (GameObject.FindWithTag("Manager") != gameObject))
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void FixedUpdate()
    {
        GameController.playerJumpSpeed = PlayerJumpSpeed;
        GameController.playerMoveAcceleration = PlayerMoveAcceleration;
        GameController.playerMoveSpeed = PlayerMoveSpeed;
        GameController.enemiesMoveSpeed = EnemiesMoveSpeed;
        for (int i = 0; i < CoinColorByValue.Length; i++)
        {
            GameController.coinColorByValue[i] = CoinColorByValue[i];
        }
        
    }
}
