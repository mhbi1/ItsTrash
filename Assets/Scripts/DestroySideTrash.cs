using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySideTrash : MonoBehaviour {
	//GameController gc;

	void Start() {
		//GameObject gcObject = GameObject.FindGameObjectWithTag ("GameController");
		//gc = gcObject.GetComponent<GameController> ();
	}

	// Destroys item and updates total money
	void OnTriggerEnter2D(Collider2D other){
		Destroy (other.gameObject);
	}
}
