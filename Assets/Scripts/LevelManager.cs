using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	private SimplePlatformController player;
	private float gravityStore;

	public GameObject currentCheckpoint;
	public GameObject deathParticle;
	public GameObject respawnParticle;
	
	public float respawnDelay;
	
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<SimplePlatformController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RespawnPlayer()
	{
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo(){

		Instantiate (deathParticle, player.transform.position, player.transform.rotation);								// Instantiate death particle effect when player dies
		player.enabled = false;																							// Disable player controls
		player.GetComponentInChildren<Renderer> ().enabled = false; 													// Make player disappear
		gravityStore = player.GetComponentInChildren<Rigidbody2D>().gravityScale;										// Get player's original gravity scale
		player.GetComponentInChildren<Rigidbody2D> ().gravityScale = 0f;												// Set gravity to 0 so player stops falling
		yield return new WaitForSeconds (respawnDelay);																	// Delay between respawn and death
		CoinCounter.loseCoins();																						// Reset coins and coin count
		player.GetComponentInChildren<Rigidbody2D> ().gravityScale = gravityStore;										// Reset player's gravity
		player.transform.position = currentCheckpoint.transform.position;												// Respawn player at checkpoint
		player.enabled = true;																							// Enable player controls
		player.GetComponentInChildren<Renderer> ().enabled = true;														// Make player reappear
		Instantiate (respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);		// Instantiate respawn particle effect when player respawns
	}
}
