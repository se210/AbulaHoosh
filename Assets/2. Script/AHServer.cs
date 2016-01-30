using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class AHServer : MonoBehaviour {

	public NetworkDiscovery networkDiscovery;
	public int serverPort;
	NetworkServerSimple server = null;

	// Use this for initialization
	void Start () {
		serverBroadcast();
		serverSetup();
	}
	
	// Update is called once per frame
	void Update () {
		if (server != null)
		{
			server.Update();
		}
	}

	void serverBroadcast()
	{
		if (!networkDiscovery.Initialize())
		{
			Debug.Log("NetworkDiscovery failed to initialize! Port not available.");
		}
		else
		{
			networkDiscovery.broadcastData = serverPort.ToString();
			networkDiscovery.StartAsServer();
		}
	}

	void serverSetup()
	{
		server = new NetworkServerSimple();
		server.RegisterHandler(MsgType.Connect, OnConnect);
		server.RegisterHandler(MsgType.Disconnect, OnDisconnect);
		server.RegisterHandler(AHMsg.SimpleMessage, OnSimpleMessage);

		server.Listen(serverPort);
	}

	// ------------------------ msg handlers ------------------------

	void OnConnect(NetworkMessage netMsg)
	{
		Debug.Log("Client connected.");
	}

	void OnDisconnect(NetworkMessage netMsg)
	{
		Debug.Log("Client disconnected.");
	}

	void OnSimpleMessage(NetworkMessage netMsg)
	{
		var msg = netMsg.ReadMessage<AHSimpleMessage>();
		Debug.Log("Client sent: " + msg.msg);
	}
}
