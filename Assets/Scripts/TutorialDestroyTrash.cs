using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialDestroyTrash : MonoBehaviour {
	Tutorial t;

	void Start() {
		GameObject tObject = GameObject.FindGameObjectWithTag ("GameController");
		t = tObject.GetComponent<Tutorial> ();
	}

	// Destroys item and updates total money
	void OnTriggerEnter2D(Collider2D other){
		Destroy (other.gameObject);
		t.updateTotal ();
	}
}
