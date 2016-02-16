using UnityEngine;
using System.Collections;

public class HeadPlatform : MonoBehaviour {

	public GameObject platform;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (BodySourceView.isBodyTracked ()) {
			//more magic
			platform.transform.position = new Vector3 ((BodySourceView.getX ()+100)/3, 50, 0);
		}
	}
}
