using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject caughtMsg;
    [SerializeField] private Text coinTx;

    private GameObject player;
    

    void Awake()
    {
        if (GameObject.FindWithTag("HUD") && (GameObject.FindWithTag("HUD") != gameObject))
        {
            Destroy(gameObject);
        }
        player = GameObject.FindWithTag("Player");
        DontDestroyOnLoad(gameObject);
    }



    void Update()
    {
        coinTx.text = GameController.coins.ToString();
        if(Input.GetKeyDown(KeyCode.Escape) && !GameController.gameIsPaused && !caughtMsg.activeSelf)
        {
            Pause();
        }
        if(Input.GetMouseButtonDown(0) && caughtMsg.activeSelf)
        {
            Time.timeScale = 1.0f;
            caughtMsg.SetActive(false);
            pauseMenu.SetActive(false);
            GameController.gameIsPaused = false;
            GameController.coins = 0;
            GameController.loadScene("Stage1");
            player.transform.position = Vector3.zero;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        GameController.gameIsPaused = false;
        GameController.resetScene();
        player.transform.position = Vector3.zero;
    }

    public void Caught()
    {
        Time.timeScale = 0.0f;
        caughtMsg.SetActive(true);
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
        GameController.gameIsPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        GameController.gameIsPaused = false;
    }
}
