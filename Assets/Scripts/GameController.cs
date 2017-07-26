using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Helper {
	public int value;
	public int num;
}

public class GameController : MonoBehaviour {
	public Button[] helperButtons;
	public GameObject item;
	public Text totalMoneyText;
	public Text[] helperNum;
	public Helper[] hList;
	public ItemManager im;
	public int totalMoney;
	int current = 0;
	float time = 0.0f;

	// Use this for initialization
	void Start () {
		//Initialize a new array 
		hList = new Helper[9];
		setupHelpers ();
	}

	// Update is called once per frame
	void Update (){
	//Creates the trash item
		current = im.current;
		//Mouse clicking
		if (Input.GetMouseButtonDown (0)){
			Debug.Log ("Button pressed.");
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
		//Checks for time constraint, if met loop through array of helpers
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

	}

	public void destroyTrash(){
		//Updates the total money with the trash item value
		totalMoney = int.Parse (totalMoneyText.text);
		totalMoney += im.items[current].value;
		//Debug.Log ("Item " + current + " value is " + im.items[current].value);
		totalMoneyText.text = "" + totalMoney;
	}

	void setupHelpers() {
		//Initiate new array of helpers
		//Adds functionality to all buttons and sets up text
		for (int h = 0; h < hList.Length; h++) {
			hList [h] = new Helper ();
			hList [h].num = 0;
			Button btn = helperButtons [h].GetComponent<Button> ();
			btn.onClick.AddListener (addHelper);
			helperNum [h].text = "x" + hList [h].num;
		}
		//Manually set values of helpers
		hList [0].value = 1;
		hList [1].value = 5;
		hList [2].value = 25;
		hList [3].value = 500;
		hList [4].value = 800;
		hList [5].value = 1500;
		hList [6].value = 10000;
		hList [7].value = 500000;
		hList [8].value = 1000000;
	}

	void addHelper(){
		//Check to see player has enough money to buy
		hList[current].num ++;
	}

	int getHelper(int n){
		return 0;
	}

}
