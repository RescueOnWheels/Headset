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

		// Vertical limit
		var x = target.eulerAngles.x;
		if(target.eulerAngles.x < 180) {
			x = Mathf.Clamp(x, 0, 18);
		}
		else {
			x = Mathf.Clamp(x, 270, 360);
		}
		
		// Horizontal limit
		var y = target.eulerAngles.y;
		if(y < 180) {
			y = Mathf.Clamp(y, 0, 90);
		}
		else {
			y = Mathf.Clamp(y, 270, 360);
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
