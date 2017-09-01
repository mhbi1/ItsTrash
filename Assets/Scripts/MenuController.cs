using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
	public Button exitBtn;
	public Button prestigeBtn;
	public Button creditsBtn;
	public Button settingsBtn;
	public GameObject menuPanel;
	public GameObject prestigePanel;
	public GameController gc;
	public Image goal;
	public Sprite prestige0;
	public Sprite prestige1;
	public Sprite prestige2;
	public Sprite prestige3;

	// Use this for initialization
	void Start () {
		Button btn = exitBtn.GetComponent<Button> ();
		Button btn2 = prestigeBtn.GetComponent<Button> ();
		//Button btn3 = creditsBtn.GetComponent<Button> ();
		btn.onClick.AddListener (exitMenu);
		btn2.onClick.AddListener (showPrestige);
		setupGoal ();
	}
	
	void exitMenu() {
		menuPanel.SetActive (false);
	}

	//Each time you upgrade prestige, item values go down
	void showPrestige() {
		prestigePanel.SetActive (true);
		menuPanel.SetActive (false);
	}
		
	void setupGoal(){
		if (gc.getPrestige () == 0) {
			goal.sprite = prestige0;
		} else if (gc.getPrestige () == 1) {
			goal.sprite = prestige1;
		} else if (gc.getPrestige () == 2) {
			goal.sprite = prestige2;
		}else {
			goal.sprite = prestige3;
		}
	}
}
