using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleItemHelper : MonoBehaviour {
	public bool toggled;
	public Button helperBtn;
	public Button itemBtn;
	public GameObject itemPanel;
	public GameObject helperPanel;

	// Mouse Clicking
	void Start(){
		Button btn = itemBtn.GetComponent<Button> ();
		Button btn2 = helperBtn.GetComponent<Button> ();
		btn.onClick.AddListener(toggleItem);
		btn2.onClick.AddListener(toggleHelper);
	}

	//Toggle = True
	void toggleItem(){
		if (!toggled) {
			toggled = true;
			itemPanel.SetActive (true);
			helperPanel.SetActive (false);
		} 
	}

	//Toggle = False
	void toggleHelper(){
		if (toggled) {
			toggled = false;
			helperPanel.SetActive (true);
			itemPanel.SetActive (false);
		}
	}
}
