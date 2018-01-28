using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
	public GameObject mainMenu;

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
//		mainMenu.SetActive (false);
	}
}
