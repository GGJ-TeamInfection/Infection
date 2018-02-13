using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [Header("In Game Stuff")]
    public Text uiText;
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


    public int infected = 0;
    public int possibleInfected = 0;
    public static GameManager instance;
	
    // Use this for initialization
	void Start ()
    {
        instance = this;
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        curTime += Time.deltaTime;
        if(infected == possibleInfected)
        {
            win = true;

        }

        if(win)
        {
            uiText.gameObject.SetActive(false);
            HideMenus();
            victoryCanvas.SetActive(true);
            Time.timeScale = Mathf.Clamp01(Time.timeScale - (Time.unscaledDeltaTime / 2));
            return;
        }

        if (curTime >= timeLimit)
        {
            gameOver = true;
            uiText.gameObject.SetActive(false);
            HideMenus();
            loseCanvas.SetActive(true);
            Time.timeScale = Mathf.Clamp01(Time.timeScale - (Time.unscaledDeltaTime / 2));
            return;
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
            uiText.enabled = false;
        }
        else 
        {
            uiText.enabled = true;
            uiText.text = "Time Left: " + (int)(timeLimit - curTime) + "\nGoal: " + GameManager.instance.infected + "/" + GameManager.instance.possibleInfected;
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
