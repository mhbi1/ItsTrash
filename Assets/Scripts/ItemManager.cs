using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item{
	public Button name;
	public Button buyItem;
	public GameObject prefab;
	public float value;        //Item's value when thrown into hole
	public float dValue;		//Item's deteriorating value
	public float cValue;		//Item's cost to restock
	public float rValue;		//Item's restock value
	public int stock;
}

/*   1 - Can
 	 2 - Beer Bottle
 	 3 - Chair
	 4 - Keyboard
	 5 - iPhone
	 6 - Macbook
	 7 - Piano
	 8 - Yacht
	 9 - Golden Piano
 */

public class ItemManager : MonoBehaviour {
	public Item[] items;
	public Item currentItem;
	public Text[] itemValues;
	public Text totalMoneyText;
	public int current;
	public int prestige = 0;
	public GameController gc;

	void Start () {
		current = 0;
		setupValues ();
		currentItem = items [0];
		updateItemValues ();
		/*/Adds functionality to items and initiates items
		for(int i = 0; i < items.Length; i++) {
			Button btn = items [i].name.GetComponent<Button> ();
			int temp = i;
			btn.onClick.AddListener (delegate{changeItem(temp);});
			if (i == 0) {
				items [i].bought = true;
			} else {
				items [i].bought = false;
			}
		}*/
	}

	public void setupValues(){
		// Manually set first item
		// Initial, restock, and deteriorate value of can
		items[0].value = 0.5f;
		items[0].cValue = 1.0f;
		items[0].rValue = 1.0f;
		items[0].dValue = .05f;
		items [0].stock = 20;
		Button btn1 = items[0].name.GetComponent<Button> ();
		Button btn2 = items[0].buyItem.GetComponent<Button> ();
		btn1.onClick.AddListener (delegate{changeItem(0);});
		btn2.onClick.AddListener (delegate{buyItem(0);});
		for (int i = 1; i < items.Length; i++) {
			Button btn = items [i].name.GetComponent<Button> ();
			Button buyBtn = items [i].buyItem.GetComponent<Button> ();
			int temp = i;
			//If image is clicked, the current item will be changed
			btn.onClick.AddListener (delegate{changeItem(temp);});
			//If buy button is clicked, the current item will be bought
			buyBtn.onClick.AddListener (delegate{buyItem(temp);});
			//Initalizes all item values and stock
			items [i].value = items [i - 1].value * 10;
			items [i].cValue = items [i - 1].cValue * 10;
			items [i].rValue = items [i - 1].rValue * 10;
			items [i].dValue = items [i - 1].dValue * 10;
			items [i].stock = 0;
		}
		currentItem = items [0];
	}

	void Update () {}

	void changeItem(int c){
		//Switches to the selected item
		current = c;
		currentItem = items [c];

		//Updates UI
		gc.getCurrentItemInfo ();
		updateItemValues ();
	}

	void buyItem(int c){
		/*  Check to see if player has enough money to buy
			Adds more stock to the item
			Item value deteriorates (value - dValue)
			Increases restock value
		*/
		if (gc.totalMoney >= items [c].cValue) {
			gc.totalMoney -= items [c].cValue;
			totalMoneyText.text = gc.formatMoney (gc.totalMoney);
			current = c;
			currentItem = items [c];
			gc.notificationText.text = getAddingStock () + " more " + items [c].name.name.ToString () + "s have been bought!";

			items [c].stock += getAddingStock ();

			//Items deteriorate to 0 with each purchase
			if (items [c].value > 0) {
				items [c].value -= items [c].dValue;
			}

			//Increases cost by base restock value
			items [c].cValue += items [c].rValue;

			//Updates UI
			gc.getCurrentItemInfo ();
			updateItemValues ();
		} else {
			gc.notificationText.text = "Not enough money.";
		}

		/*/float totalMoney = float.Parse (totalMoneyText.text);
		if (gc.totalMoney >= items [c].value) {
			items [c].bought = true;
			gc.totalMoney -= items [c].value;
			totalMoneyText.text = gc.formatMoney (gc.totalMoney);
			current = c;
			Debug.Log ("Item successfully bought.");
		} else {
			Debug.Log ("Not enough money.");
		}*/
	}

	public bool hasStock(int i) {
		return items[i].stock > 0 ? true : false;
	}

	public void subtractStock(){
		items [current].stock--;
	}

	public GameObject getItem(){
		return items [current].prefab;
	}

	public string getName(){
		return items [current].name.name;
	}

	public float getValue(){
		return items [current].value;
	}

	public int getStock(){
		return items [current].stock;
	}

	public float getCValue(){
		return items [current].cValue;
	}

	public int getPrestige() {
		return prestige;
	}

	int getAddingStock(){
		/*
			items[0-2] get 15 more stock
			items[3-5] get 10 more stock
			items[6-8] get 5 more stock
			*/
		if (current < 3) {
			return 20;
		} else if (current < 6) {
			return 15;
		} else {
			return 10;
		}
	}

	//Manually set values of items depending on prestige
	public void updateValues() {
		current = 0;
		/*if (prestige == 1) {
			items [0].value = .50;
			items [1].value = 2.50;
			items [2].value = 12.50;
			items [3].value = 250;
			items [4].value = 500;
			items [5].value = 1250;
			items [6].value = 10000;
			items [7].value = 400000;
			items [8].value = 7500000;
		}else if (prestige == 2) {
			items [0].value = .25;
			items [1].value = 1.25;
			items [2].value = 6.25;
			items [3].value = 125;
			items [4].value = 400;
			items [5].value = 1000;
			items [6].value = 7500;
			items [7].value = 300000;
			items [8].value = 5000000;
		}else if (prestige == 3) {
			items [0].value = .10;
			items [1].value = .75;
			items [2].value = 3.75;
			items [3].value = 75;
			items [4].value = 300;
			items [5].value = 750;
			items [6].value = 5000;
			items [7].value = 200000;
			items [8].value = 2500000;
		}else if (prestige == 4) {
			items [0].value = .05;
			items [1].value = .50;
			items [2].value = 2.50;
			items [3].value = 50;
			items [4].value = 200;
			items [5].value = 500;
			items [6].value = 2500;
			items [7].value = 100000;
			items [8].value = 1250000;
		}else if (prestige == 5) {
			items [0].value = .01;
			items [1].value = .25;
			items [2].value = 1.25;
			items [3].value = 25;
			items [4].value = 100;
			items [5].value = 250;
			items [6].value = 1000;
			items [7].value = 50000;
			items [8].value = 750000;
		}*/
	}

	public void updateItemValues() {
		for(int t = 0; t < itemValues.Length; t++) {
			string shrt = gc.formatMoney (items [t].cValue);
			itemValues [t].text = shrt;
		}
	}
}
