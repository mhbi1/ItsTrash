using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item{
	public Button name;
	public GameObject prefab;
	public int value;
	public int pValue;
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
	public Text totalMoneyText;
	public int current;

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
		int totalMoney = int.Parse (totalMoneyText.text);
		if (totalMoney >= items [c].value) {
			items [c].bought = true;
			totalMoney -= items [c].value;
			totalMoneyText.text = totalMoney.ToString ();
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
}
