using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.IO;

public class AHServer : MonoBehaviour {

	public NetworkDiscovery networkDiscovery;
	public int serverPort;
	NetworkServerSimple server = null;
	NetworkConnection[] playerConnections = new NetworkConnection[2];
	Byte[][] playerVoiceBuffer = new Byte[2][];

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
		server.RegisterHandler(AHMsg.VoiceFileInfoMessage, OnVoiceFileInfoMessage);
		server.RegisterHandler(AHMsg.VoiceFileMessage, OnVoiceFileMessage);
		server.RegisterHandler(AHMsg.VoiceFileCompleteMessage, OnVoiceFileCompleteMessage);

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

	void OnVoiceFileInfoMessage(NetworkMessage netMsg)
	{
		var msg = netMsg.ReadMessage<AHVoiceFileInfoMessage>();
		playerVoiceBuffer[msg.playerNum] = new Byte[msg.fileSize];
		Debug.Log(string.Format("Player {0} voice transfer initiated. File size: {1} bytes.", msg.playerNum, msg.fileSize));
	}

	void OnVoiceFileMessage(NetworkMessage netMsg)
	{
		var msg = netMsg.ReadMessage<AHVoiceFileMessage>();
		Array.Copy(msg.bytes, 0, playerVoiceBuffer[msg.playerNum], msg.index, msg.bytes.Length);
		Debug.Log(string.Format("Player {0} receiving voice data. Index: {1} ({2} bytes).", msg.playerNum, msg.index, msg.bytes.Length));
	}

	void OnVoiceFileCompleteMessage(NetworkMessage netMsg)
	{
		var msg = netMsg.ReadMessage<AHVoiceFileCompleteMessage>();
		string filePath = Application.persistentDataPath + string.Format("/player{0}.wav",msg.playerNum);
		File.WriteAllBytes(filePath, playerVoiceBuffer[msg.playerNum]);
		Debug.Log(string.Format("Player {0} voice transfer completed.", msg.playerNum));

		// Example for playing an audio clip
		AudioSource aud = gameObject.AddComponent<AudioSource>();
		WWW www = new WWW("file://"+filePath);
		aud.clip = www.audioClip;
		while(aud.clip.loadState != AudioDataLoadState.Loaded);
		aud.Play();
	}
}
