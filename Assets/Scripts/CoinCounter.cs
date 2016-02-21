using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class CoinCounter : MonoBehaviour {

	private static int score;
	//private static ArrayList coins = new ArrayList ();
	private static Collectible[] coins;

	Text text;

	// Use this for initialization
	void Start () {

		text = GetComponent<Text> ();

		score = 0;

		coins = FindObjectsOfType<Collectible> ();
	
	}

	// Update is called once per frame
	void Update () {
	
		if (score < 0)
			score = 0;

		text.text = "x" + score;
	}

	public static void addCoin(int noOfCoins){

		score += noOfCoins;
	}

	public static void loseCoins(){
		score = 0;
		for (int i = 0; i < coins.Length; i++) {
			coins[i].resetCollectible();
		}
	}
}
