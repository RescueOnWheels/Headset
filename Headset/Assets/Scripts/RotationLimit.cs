using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLimit : MonoBehaviour {
	public GameObject camera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion target = camera.transform.rotation;

		// Limit the X-axis between -45 and 45.
		var x = target.eulerAngles.x;
		if(target.eulerAngles.x < 180) {
			x = Mathf.Clamp(x, 0, 45);
		}
		else {
			x = Mathf.Clamp(x, 315, 360);
		}
		
		var y = target.eulerAngles.y;
		if(y < 180) {
			y = Mathf.Clamp(y, 0, 45);
		}
		else {
			y = Mathf.Clamp(y, 315, 360);
		}

		// Disable rotation on the Z-axis
		target.eulerAngles = new Vector3(
			x,
			y, 
			0
		);

		transform.rotation = target;
	}
}
