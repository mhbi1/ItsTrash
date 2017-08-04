using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrestigeController : MonoBehaviour {
	public Button backBtn;
	public Button resetBtn;
	public GameObject menuPanel;
	public GameObject prestigePanel;
	public GameController gc;
	public Text tmText;
	int TMs;

	void Start () {
		Button btn = backBtn.GetComponent<Button> ();
		Button btn2 = resetBtn.GetComponent<Button> ();
		btn.onClick.AddListener (backToMenu);
		btn2.onClick.AddListener (restartGame);
		tmText.text = "x" + getTMs ();
	}

	void Update() {
		tmText.text = "x" + getTMs ();
	}
	
	//Gets level of prestige (# of time machines)
	int getTMs () {
		return gc.getPrestige ();
	}

	void backToMenu() {
		menuPanel.SetActive (true);
		prestigePanel.SetActive (false);
	}

	void restartGame() {
		gc.buyTM ();
		gc.setItemValues ();
		gc.resetGame ();
	}
}
