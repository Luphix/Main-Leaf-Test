using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameController
{
    public static bool gameIsPaused = false;
    public static bool playerBusy = false;
    public static int stage = 1;
    public static int concludedStages = 0;
    public static int stagePart = 1;
    public static int puzzleCount;
    public static int puzzleMaxCount;
    public static int coins = 0;
    public static float playerMoveSpeed;
    public static float playerMoveAcceleration;
    public static float playerJumpHeight;
    public static float enemiesMoveSpeed;
    public static float enemiesStoppedDuration;
    public static float enemiesWalkingDuration;
    public static Color[] coinColorByValue = new Color[5];

    public static void loadScene(string name)
    {
        Time.timeScale = 1f;
        
        SceneManager.LoadScene(name);
        if (name == "Stage1")
        {
            GameController.stage = 1;
        }
        else if(name == "Stage2")
        {
            GameController.stage = 2;
        }
        else
        {
            GameController.stage = 3;
        }
            
    }

    public static void resetScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        coins = 0;
    }

    public static void resetGame()
    {
        gameIsPaused = false;
        playerBusy = false;
        stage = 1;
        concludedStages = 0;
        stagePart = 1;
        puzzleCount = 0;
        puzzleMaxCount = 2;
        coins = 0;
        SceneManager.LoadScene("Stage1");
    }
}
