using UnityEngine;
using System.Collections;

public class ButtonBox : MonoBehaviour {

	private static bool inBox;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer> ().material.color = Color.red;
		inBox = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.transform.tag == "Player") {
			inBox = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.transform.tag == "Player") {
			inBox = false;
		}
	}

	public static bool isInBox() {
		return inBox;
	}
}
