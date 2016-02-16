using UnityEngine;
using System.Collections;

public class ExitPortal : MonoBehaviour {
	
	private static bool inPortal;
	
	// Use this for initialization
	void Start () {
		inPortal = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		//numCollected requirement will change per level; hash this out somehow
		if (other.transform.tag == "Player" && Collectible.numCollected() == 4) {
			inPortal = true;
		}
	}	
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.transform.tag == "Player") {
			inPortal = false;
		}
	}
	
	public static bool isInPortal() {
		return inPortal;
	}
}