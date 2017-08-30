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

	//Toggle = Items Panel active
	void toggleItem(){
		if (!toggled) {
			toggled = true;
			itemPanel.SetActive (true);
			helperPanel.SetActive (false);
		} 
	}

	//Toggle = Helper Panel active
	void toggleHelper(){
		if (toggled) {
			toggled = false;
			helperPanel.SetActive (true);
			itemPanel.SetActive (false);
		}
	}
}
