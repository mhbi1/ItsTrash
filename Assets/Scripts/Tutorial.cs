using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {
	int steps = 0;
	public Button helpers;
	public GameObject itemPanel;
	public GameObject helperPanel;
	public GameObject step1A;
	public GameObject step1T;
	public GameObject step2A;
	public GameObject step2T;
	public GameObject step3A;
	public GameObject step3T;
	public GameObject step4A;
	public GameObject step4T;
	public GameObject step5;
	public GameObject startBtn;
	public Button start;

	void Start() {
		Button btn = start.GetComponent<Button> ();
		btn.onClick.AddListener (startGame);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)){
			steps++;
			if (steps == 1) {
				step1A.SetActive (false);
				step1T.SetActive (false);
				step2A.SetActive (true);
				step2T.SetActive (true);
			} else if (steps == 2) {
				step2A.SetActive (false);
				step2T.SetActive (false);
				step3A.SetActive (true);
				step3T.SetActive (true);
			} else if (steps == 3) {
				step3A.SetActive (false);
				step3T.SetActive (false);
				helpers.GetComponent<Image> ().color = Color.red;
			} else if (steps == 4) {
				step4A.SetActive (true);
				step4T.SetActive (true);
				helperPanel.SetActive (true);
				itemPanel.SetActive (false);
				helpers.GetComponent<Image> ().color = Color.white;
			} else if (steps == 5) {
				step4A.SetActive (false);
				step4T.SetActive (false);
				step5.SetActive (true);
				startBtn.SetActive (true);
			}
		}
	}

	void startGame() {
		SceneManager.LoadScene ("GameScreen");
	}
}
