using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour {

	public Button yesBtn;
	public Button yes2Btn;
	public GameObject prologue1;
	public GameObject prologue2;
	public GameObject prologue3;
	public GameObject mammon;

	int steps = 0;

	// Use this for initialization
	void Start () {
		Button btn = yesBtn.GetComponent<Button> ();
		Button btn2 = yes2Btn.GetComponent<Button> ();
		btn.onClick.AddListener (acceptDeal);
		btn2.onClick.AddListener (acceptDeal);
	}
	
	void Update () {
		if (Input.GetMouseButtonDown (0)){
			steps++;
			if (steps == 1) {
				prologue1.SetActive (false);
				prologue2.SetActive (true);
				mammon.SetActive (true);
			} else if (steps == 3) {
				SceneManager.LoadScene ("Tutorial");
			}
		}
	}

	void acceptDeal() {
		//Set screen to black mammon disappears
		mammon.SetActive (false);
		prologue2.SetActive (false);
		prologue3.SetActive (true);
	}
}
