using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [Header("In Game Stuff")]
    public Text timerText;
    public int goal;
    public int score;

    
    [HideInInspector]
    public float curTime;
    [Header("Timer")]
    public float timeLimit;

    [Header("Menus")]
    public GameObject pauseCanvas;
    public GameObject victoryCanvas, loseCanvas;

    [HideInInspector]
    public bool paused = false;
    [HideInInspector]
    public bool gameOver = false;
    [HideInInspector]
    public bool win = false;
	
    // Use this for initialization
	void Start ()
    {
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        curTime += Time.deltaTime;
        if (curTime >= timeLimit && !gameOver)
        {
            print("Do game over stuff!");
            timerText.gameObject.SetActive(false);
            HideMenus();
            loseCanvas.SetActive(true);
            Time.timeScale -= Time.unscaledDeltaTime/2;
        }
        if(Input.GetButtonDown("Cancel")&& !gameOver && !win)
        {
            paused = !paused;
            if(paused)
            {
                HideMenus();
                pauseCanvas.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                HideMenus();
                Time.timeScale = 1;
            }
        }

        if(paused || gameOver || win)
        {
            timerText.enabled = false;
        }
        else 
        {
            timerText.enabled = true;
            timerText.text = "Time Left: " + (int)(timeLimit - curTime);
        }

        
	}

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void HideMenus()
    {
        pauseCanvas.SetActive(false);
        victoryCanvas.SetActive(false);
        loseCanvas.SetActive(false);
    }
}
