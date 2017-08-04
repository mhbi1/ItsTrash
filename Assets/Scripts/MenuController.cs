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

	// Use this for initialization
	void Start () {
		Button btn = exitBtn.GetComponent<Button> ();
		Button btn2 = prestigeBtn.GetComponent<Button> ();
		//Button btn3 = creditsBtn.GetComponent<Button> ();
		btn.onClick.AddListener (exitMenu);
		btn2.onClick.AddListener (showPrestige);
		
	}
	
	void exitMenu() {
		menuPanel.SetActive (false);
	}

	//Each time you upgrade prestige, item values go down
	void showPrestige() {
		prestigePanel.SetActive (true);
		menuPanel.SetActive (false);
	}
}
