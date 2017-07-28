using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {

	public Button startBtn;
	public Button h2pBtn;

	// Use this for initialization
	void Start () {
		Button btn = startBtn.GetComponent<Button> ();
		Button btn2 = h2pBtn.GetComponent<Button> ();
		btn.onClick.AddListener (startGame);
		btn2.onClick.AddListener (toTutorial);
		Debug.Log (SceneManager.sceneCountInBuildSettings);
	}

	void startGame() {
		SceneManager.LoadScene ("GameScreen");
	}

	void toTutorial() {
		SceneManager.LoadScene ("Tutorial");
	}
}
