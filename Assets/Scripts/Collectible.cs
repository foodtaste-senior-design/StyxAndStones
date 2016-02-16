using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {

	private static int coinsCollected;

	// Use this for initialization
	void Start () {
		coinsCollected = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.transform.tag == "Player") {
			coinsCollected++;
			//GetComponent<Renderer>().enabled = false;	
			Destroy(gameObject);			// Collectible needs to be destroyed not invisible
			CoinCounter.addCoin(1);			// increase coin count
		}
	}
	
	public static int numCollected() {
		return coinsCollected;
	}
}
