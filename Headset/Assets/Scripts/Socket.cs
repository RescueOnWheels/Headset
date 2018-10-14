using System.Collections;
using System.Collections.Generic;
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
		
	}

	void OnDestroy() {
		socket.Disconnect();
	}
}
