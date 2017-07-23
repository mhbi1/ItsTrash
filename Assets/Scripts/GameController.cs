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
	public Helper[] hList;
	int totalMoney;
	int current = 0;
	float time = 0.0f;

	// Use this for initialization
	void Start () {
		//Initialize a new array 
		hList = new Helper[10];
		for(int h = 0; h < hList.Length; h++){
			hList[h] = new Helper();
			hList[h].value = 1;
			hList[h].num = 0;
		}
		Button btn = helperButtons[0].GetComponent<Button> ();
		btn.onClick.AddListener(addHelper);
	}

	// Update is called once per frame
	void Update (){
	//Creates the trash item
		//Mouse clicking
		if (Input.GetMouseButtonDown (0)){
			Debug.Log ("Button pressed.");
			var mousePos = Input.mousePosition;
			mousePos.z = 1.0f;
			var objectPos = Camera.main.ScreenToWorldPoint (mousePos);
			if (objectPos.y > 1.5) {
				Instantiate (item, objectPos, Quaternion.identity);
			}
		}

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

	void addHelper(){
		//Check to see player has enough money to buy
		hList[current].num ++;
	}

	public void destroyTrash(){
		//Updates the total money with the trash item value
		totalMoney = int.Parse (totalMoneyText.text);
		totalMoney += hList[current].value;
		totalMoneyText.text = "" + totalMoney;
	}

	int getHelper(int n){
		return 0;
	}
}
