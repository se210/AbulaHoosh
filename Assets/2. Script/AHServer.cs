using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class AHServer : MonoBehaviour {

	public NetworkDiscovery networkDiscovery;
	public int serverPort;
	NetworkServerSimple server = null;
	NetworkConnection[] playerConnections = new NetworkConnection[2];

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
		for (int i=0; i < playerConnections.Length; i++)
		{
			if (playerConnections[i] == null)
			{
				playerConnections[i] = netMsg.conn;
				AHConnectMessage connMsg = new AHConnectMessage();
				connMsg.playerNum = i;
				playerConnections[i].Send(AHMsg.ConnectMessage, connMsg);
				Debug.Log(string.Format("Player {0} connected.", i));
				break;
			}
		}
	}

	void OnDisconnect(NetworkMessage netMsg)
	{
		for (int i=0; i < playerConnections.Length; i++)
		{
			if (playerConnections[i] == netMsg.conn)
			{
				playerConnections[i] = null;
				Debug.Log(string.Format("Player {0} disconnected.", i));
				break;
			}
		}
	}

	void OnSimpleMessage(NetworkMessage netMsg)
	{
		var msg = netMsg.ReadMessage<AHSimpleMessage>();
		Debug.Log("Client sent: " + msg.msg);
	}
}
