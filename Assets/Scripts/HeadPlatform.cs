using UnityEngine;
using System.Collections;

public class HeadPlatform : MonoBehaviour {

	public GameObject platform;
	public Transform platformMin;				// The leftmost point to which the platform should move to
	public Transform platformMax;				// The rightmost point to which the platform should move to
	private float kinectMin_x = 200;			// The leftmost point to which the players head should move
	private float kinectMax_x = 400;			// The rightmost point to which the players head should move

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (BodySourceView.isBodyTracked ()) {
			//more magic - (old code - remove after testing)
			//platform.transform.position = new Vector3 ((BodySourceView.getX ()+100)/3, 50, 0);

			float platformMin_x = platformMin.position.x;	// Minimum x value for platform
			float platformMax_x = platformMax.position.x;	// Maximum x value for platform
			float head_x = BodySourceView.getX();			// Position of head from Kinect

			float relativeKinectDistance = (head_x - kinectMin_x)/(kinectMax_x - kinectMin_x);
			float platform_x = (relativeKinectDistance * (platformMax_x - platformMin_x)) + platformMin_x;							// New x value for platform
			platform.transform.position = new Vector3 (platform_x, platform.transform.position.y, platform.transform.position.z);

		}
	}
}
