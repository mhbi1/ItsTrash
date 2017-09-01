using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {
	public Button itemsBtn;
	public Button helpersBtn;
	public Button menu;
	public Button start;
	public Button buy;
	public Button canHelper;

	public Text goldPerTSeconds;
	public Text canHelperNum;
	public Text canHelperValue;
	public Text totalMoneyText;
	public Text notificationText;
	public Text canCostValue;
	public Text currentItemStock;
	public Text currentItemName;
	public Text currentItemValue;
	public Image currentItemImage;

	public GameObject items;
	public GameObject helpers;
	public GameObject itemPanel;
	public GameObject helperPanel;
	public GameObject gps;
	public GameObject step1A;
	public GameObject step1T;
	public GameObject step2A;
	public GameObject step2T;
	public GameObject step3A;
	public GameObject step3T;
	public GameObject step4A;
	public GameObject step4T;
	public GameObject warning;
	public GameObject step5;
	public GameObject step6A;
	public GameObject step6T;
	public GameObject step7;
	public GameObject startBtn;
	public ItemManager im;
	public GameObject item;
 

	int steps = 0;
	float totalMoney = 0.0f;
	bool stepDisplay = true;

	void Start() {
		Button btn = start.GetComponent<Button> ();
		btn.onClick.AddListener (startGame);
		itemPanel.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && stepDisplay){
			steps++;
			if (steps == 1) {
				//Throwing trash into hole
				itemPanel.SetActive (true);
				items.SetActive (true);
				step1A.SetActive (false);
				step1T.SetActive (false);
				step2A.SetActive (true);
				step2T.SetActive (true);
			} else if (steps == 2) {
				step2A.SetActive (false);
				step2T.SetActive (false);
				stepDisplay = false;
			} else if (steps == 3) {
				step3A.SetActive (true);
				step3T.SetActive (true);
				notificationText.text = "";
				currentItemValue.color = Color.black;
				currentItemValue.fontStyle = FontStyle.Normal;
			} else if (steps == 4) {
				step3A.SetActive (false);
				step3T.SetActive (false);
				step4A.SetActive (true);
				step4T.SetActive (true);
				buy.GetComponent<Image> ().color = Color.red;
				initiateBuyButton ();
			} else if (steps == 5) {
				warning.SetActive (false);
				step5.SetActive (true);
				itemPanel.SetActive (false);
				items.SetActive (false);
				helpers.SetActive (true);
				notificationText.text = "";
				initiateHelpersButton ();
			} else if (steps == 6) {
				step6A.SetActive (true);
				step6T.SetActive (true);
				gps.SetActive (true);
				initiateCanHelperButton ();
				stepDisplay = false;
			} else if (steps == 7) {
				step7.SetActive (true);
				startBtn.SetActive (true);
			}
		}
		/*step5.SetActive (true);
				helpers.GetComponent<Image> ().color = Color.red;
				helpers.GetComponent<Image> ().color = Color.white;
					helperPanel.SetActive (true);
				itemPanel.SetActive (false);
				startBtn.SetActive (true);*/
		if (!stepDisplay && steps == 2) {
			step2A.SetActive (false);
			step2T.SetActive (false);
			if (Input.GetMouseButtonDown (0)) {
				createTrash ();
			}
			currentItemValue.color = Color.red;
			currentItemValue.fontStyle = FontStyle.Bold;
		}
		//Debug.Log ("Step " + steps);
	}

	public void updateTotal(){
		//Updates the total money with the trash item value
		totalMoney += im.currentItem.value;
		//Debug.Log ("Item value is " + im.items[0].value);
		//Debug.Log ("totalMoney is " + totalMoney);
		totalMoneyText.text = totalMoney.ToString ("f2");
	}

	void initiateBuyButton(){
		Button btn = buy.GetComponent<Button> ();
		btn.onClick.AddListener(buyTutorialItem);
		stepDisplay = false;
	}

	void initiateHelpersButton(){
		Button btn = helpersBtn.GetComponent<Button> ();
		btn.onClick.AddListener(showHelpersPanel);
		stepDisplay = false;
	}

	void initiateCanHelperButton(){
		Button btn = canHelper.GetComponent<Button> ();
		btn.onClick.AddListener(buyTutorialHelper);
	}

	void showHelpersPanel(){
		helperPanel.SetActive (true);
		step5.SetActive (false);
		stepDisplay = true;
	}

	void buyTutorialItem(){
		buy.GetComponent<Image> ().color = Color.white;
		if (totalMoney >= 1.0f) {
			totalMoney -= 1.0f;
			totalMoneyText.text = totalMoney.ToString ("f2");
			notificationText.text = "10 more cans have been bought!";

			currentItemStock.text = "x10";
			currentItemValue.text = "0.45";
			canCostValue.text = "2";
		}
		step4A.SetActive (false);
		step4T.SetActive (false);
		warning.SetActive (true);
		stepDisplay = true;
	}

	void buyTutorialHelper() {
		step6A.SetActive (false);
		step6T.SetActive (false);
		canHelperValue.text = "$4.00";
		canHelperNum.text = "x1";
		goldPerTSeconds.text = "$1.00 every 30 seconds";
		stepDisplay = true;
	}

	void createTrash(){
		//Mouse Clicking
		var mousePos = Input.mousePosition;
		mousePos.z = 1.0f;
		var objectPos = Camera.main.ScreenToWorldPoint (mousePos);
		if (objectPos.y > 1.5) {
			item = im.getItem ();
			if (im.hasStock (0)) {
				im.subtractStock ();
				getCurrentItemInfo ();
				Instantiate (item, objectPos, Quaternion.identity);
			} else {
				notificationText.text = "No more " + im.getName () + "s.";
				stepDisplay = true;
			}
		}
	}

	void getCurrentItemInfo() {
		currentItemName.text = im.getName ();
		currentItemStock.text = "x" + im.getStock ();
		currentItemValue.text = im.getValue().ToString ("f2");
		currentItemImage.sprite = im.getItem ().GetComponent<SpriteRenderer>().sprite;
	}

	void startGame() {
		SceneManager.LoadScene ("GameScreen");
	}
}
