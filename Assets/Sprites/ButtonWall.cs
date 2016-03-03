using UnityEngine;
using System.Collections;

public class ButtonWall : MonoBehaviour {

	private BoxCollider2D collision;
	
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer> ().material.color = Color.grey;
		collision = gameObject.GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		/* for colored walls
		if (ButtonBox.isInBox ()) {
			if (gameObject.GetComponent<Renderer> ().material.color == Color.grey) {
				gameObject.GetComponent<Renderer> ().material.color = Color.green;
				collision.isTrigger = true;
			}
		}
		*/
		if (ButtonBox.isInBox ()) {
			gameObject.SetActive(false);
		}
	}
}
