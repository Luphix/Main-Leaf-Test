using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameController
{
    public static bool gameIsPaused = false;
    public static int stage = 1;
    public static int stagePart = 1;
    public static int puzzleCount;
    public static int puzzleMaxCount;
    public static int coins = 0;

    public static void loadScene(string name)
    {
        Time.timeScale = 1f;
        
        SceneManager.LoadScene(name);
        GameController.stage += 1;
    }

    public static void resetScene()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
        coins = 0;
    }
}
