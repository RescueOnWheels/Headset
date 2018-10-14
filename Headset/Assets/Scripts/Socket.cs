using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Quobject.SocketIoClientDotNet.Client;
using UnityEngine;

public class Socket : MonoBehaviour {
	Quobject.SocketIoClientDotNet.Client.Socket socket = null;
	// Use this for initialization
	void Start () {
		socket = IO.Socket("http://192.168.1.6:3000");

		socket.On("connect", () =>
		{
			socket.Emit("hi");
			
		});
	}
	
	// Update is called once per frame
	void Update () {
		var x = Math.Round(gameObject.transform.localEulerAngles.x, 2);
		var y = Math.Round(gameObject.transform.localEulerAngles.y, 2);
		var z = Math.Round(gameObject.transform.localEulerAngles.z, 2);

		var data = new {
			x,
			y,
			z
		};

		socket.Emit("headset", JsonConvert.SerializeObject(data)	);
	}

	void OnDestroy() {
		socket.Disconnect();
	}
}
