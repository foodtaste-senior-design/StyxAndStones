using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class CoinCounter : MonoBehaviour {

	public static int score;

	Text text;

	// Use this for initialization
	void Start () {

		text = GetComponent<Text> ();

		score = 0;
	
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
}
