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

	// Use this for initialization
	void Start () {
		Button btn = exitBtn.GetComponent<Button> ();
		
		btn.onClick.AddListener (exitMenu);
		
	}
	
	void exitMenu() {
		menuPanel.SetActive (false);
	}

	//Each time you upgrade prestige, item values go down
	void showPrestige() {

	}
}
