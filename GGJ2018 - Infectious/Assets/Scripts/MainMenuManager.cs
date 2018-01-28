using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
	public GameObject mainMenu;
	public GameObject aboutPanel;

	// Use this for initialization
	void Start () {
//		resetMenus ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame() {
		SceneManager.LoadScene("Level 1");
	}

	public void resetMenus() {
		mainMenu.SetActive (false);
		aboutPanel.SetActive (false);
	}

	public void showAboutPanel() {
		resetMenus ();
		aboutPanel.SetActive (true);
	}

	public void showMainMenu() {
		resetMenus ();
		mainMenu.SetActive (true);
	}
}
