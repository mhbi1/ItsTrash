using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item{
	public Button name;
	public GameObject prefab;
	public double value;
	//public int pValue;
	public bool bought;
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
	public Text[] itemValues;
	public Text totalMoneyText;
	public int current;
	public int prestige = 0;
	public GameController gc;

	void Start () {
		current = 0;
		//items = new Item[9];
		//Adds functionality to items and initiates items
		for(int i = 0; i < items.Length; i++) {
			Button btn = items [i].name.GetComponent<Button> ();
			int temp = i;
			btn.onClick.AddListener (delegate{changeItem(temp);});
			if (i == 0) {
				items [i].bought = true;
			} else {
				items [i].bought = false;
			}
		}
	}

	void Update () {}

	void changeItem(int c){
		//Check to see if item is bought or not
		if (items [c].bought) {
			Debug.Log ("Item already bought.");
			current = c;
		} else {
			buyItem (c);
		}
	}

	void buyItem(int c){
		//Check to see if player has enough money to buy
		//double totalMoney = double.Parse (totalMoneyText.text);
		if (gc.totalMoney >= items [c].value) {
			items [c].bought = true;
			gc.totalMoney -= items [c].value;
			totalMoneyText.text = gc.formatMoney (gc.totalMoney);
			current = c;
			Debug.Log ("Item successfully bought.");
		} else {
			Debug.Log ("Not enough money.");
		}
	}

	public bool isBought(int i) {
		return items [i].bought;
	}

	public GameObject getItem(){
		return items [current].prefab;
	}

	public int getPrestige() {
		return prestige;
	}

	//Manually set values of items depending on prestige
	public void updateValues() {
		current = 0;
		if (prestige == 1) {
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
		}
	}

	public void updateItemValues() {
		for(int t = 0; t < itemValues.Length; t++) {
			string shrt = gc.formatMoney (items [t].value);
			itemValues [t].text = shrt;
		}
	}
}
