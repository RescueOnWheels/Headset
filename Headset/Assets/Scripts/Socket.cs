using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Quobject.SocketIoClientDotNet.Client;
using UnityEngine;

public class Socket : MonoBehaviour {
	public string server;

	Quobject.SocketIoClientDotNet.Client.Socket socket = null;
	
	// Use this for initialization
	void Start () {
		socket = IO.Socket(server);

		socket.On("connect", () =>
		{
			Debug.Log("Connected to Larynx.");
		});
	}
	
	void LateUpdate() {
		socket.On("disconnect", () => {
			Debug.Log("Disconnected from Larynx.");
			socket = IO.Socket(server);
		});
	}

	// Update is called once per frame
	void Update () {
		double x = gameObject.transform.eulerAngles.x;
		double y = gameObject.transform.eulerAngles.y;
		double z = gameObject.transform.eulerAngles.z;

		double vertical = x;
		if(x < 180) {
			vertical = (-1 * (x / 18));
		} else {
			vertical = (1-((x-270) / 90));
		}

		vertical = Math.Round(vertical, 2);
		vertical = Math.Min(vertical, 1.00);
		vertical = Math.Max(vertical, -1.00);

		double horizontal = y;
		if(y < 180) {
			horizontal = (y / 90);
		} else {
			horizontal = (-1 - (-1 * ((y-270) / 90)));
		}

		horizontal = Math.Round(horizontal, 2);
		horizontal = Math.Min(horizontal, 1.00);
		horizontal = Math.Max(horizontal, -1.00);

		var data = "{\"horizontal\": " + (horizontal) + ", \"vertical\": " + vertical + "}";

		Debug.Log(data);

		socket.Emit("headset position", JsonConvert.SerializeObject(data));
	}

	void OnDestroy() {
		socket.Disconnect();
	}
}
