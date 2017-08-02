using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public class Helper {
	public int value;
	public int pValue;
	public int num;
}

public class GameController : MonoBehaviour {
	public Button[] helperButtons;
	public Button menu;
	public GameObject menuPanel;
	public GameObject item;
	public Text gpsText;
	public Text totalMoneyText;
	public Text[] helperNum;
	public Text[] helperCost;
	public Helper[] hList;
	public ItemManager im;
	public int totalMoney;
	public int prestige = 0;
	int gps;
	int current = 0;
	float time = 0.0f;

	void Start () {
		Button btn = menu.GetComponent<Button> ();
		btn.onClick.AddListener (showMenu);
		//Initialize a new array 
		hList = new Helper[9];
		setupHelpers ();
	}

	// Update is called once per frame
	void Update (){
	//Creates the trash item
		current = im.current;
		//Mouse clicking
		if (Input.GetMouseButtonDown (0) && !EventSystem.current.IsPointerOverGameObject()){
			//Debug.Log ("Button pressed.");
			var mousePos = Input.mousePosition;
			mousePos.z = 1.0f;
			var objectPos = Camera.main.ScreenToWorldPoint (mousePos);
			if (objectPos.y > 1.5) {
				item = im.getItem ();
				Instantiate (item, objectPos, Quaternion.identity);
			}
		}

		//Don't need?
		//Finger Pressing
		/*for (var i = 0; i < Input.touchCount; i++) {
			if (Input.GetTouch(i).phase == TouchPhase.Began) {
				var touchPos : Vector3 = Input.GetTouch(i).position;
				touchPos.z = 4.0;
				var createPos = myCam.ScreenToWorldPoint(touchPos);
				Instantiate (projectile, createPos, Quaternion.identity);
			}
		}*/

		time += Time.deltaTime;
		//Checks for time constraint. if met, loop through array of helpers
		if (time > 5) {
			foreach (Helper h in hList) {
				if (h.num > 0){
					// If helpers exist, multiply value of item by number and add to total
					int aValue = h.value * h.num;
					aValue = int.Parse(totalMoneyText.text) + aValue;
					totalMoneyText.text = aValue.ToString ();
				}
			}
			time = 0;
		}

		gpsText.text = "$" + gps + " every 30 seconds";

	}

	public void updateTotal(){
		//Updates the total money with the trash item value
		totalMoney = int.Parse (totalMoneyText.text);
		totalMoney += im.items[current].value;
		//Debug.Log ("Item " + current + " value is " + im.items[current].value);
		totalMoneyText.text = "" + totalMoney;
	}

	void showMenu(){
		menuPanel.SetActive (true);
	}

	void setupHelpers() {
		//Initiate new array of helpers
		//Adds functionality to all buttons and sets up text
		for (int h = 0; h < hList.Length; h++) {
			hList [h] = new Helper ();
			hList [h].num = 0;
			Button btn = helperButtons [h].GetComponent<Button> ();
			int temp = h;
			btn.onClick.AddListener (delegate{addHelper(temp);});
			helperNum [h].text = "x" + hList [h].num;
		}
		//Manually set values of helpers
		hList [0].value = 1;
		hList [1].value = 5;
		hList [2].value = 25;
		hList [3].value = 500;
		hList [4].value = 800;
		hList [5].value = 1500;
		hList [6].value = 20000;
		hList [7].value = 500000;
		hList [8].value = 1000000;
		//Sets up cost for helpers
		for(int h = 0; h < hList.Length; h++){
			hList[h].pValue = hList[h].value * 2;
			helperCost [h].text = "$ " + hList [h].pValue.ToString ();
		}

	}

	void addHelper(int c){
		//Check to see player has enough money to buy and if item is bought
		current = c;
		if (totalMoney >= hList [current].pValue && im.isBought (current)) {
			gps = 0;
			hList[current].num ++;
			totalMoney -= hList [current].pValue;
			totalMoneyText.text = totalMoney.ToString ();
			hList [current].pValue = hList [current].pValue * 2;
			helperCost [current].text = "$ " + hList[current].pValue;

			//Updates amount of helpers bought
			for(int h = 0; h < hList.Length; h++) {
				helperNum [h].text = "x" + hList [h].num;
				gps += hList [h].num * hList [h].value;
			}
		}
	}

	//Save for later
	//Takes the amount and formats it by shortening the amount
	string formatMoney(string m){
		/*     10K  - 10,000
		 	   100K - 100,000
		       1M   - 1,000,000
		       1B   - 1,000,000,000
		 * */
		string amount = "";


		return amount;
	}
}
