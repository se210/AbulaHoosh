using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Prepare : MonoBehaviour {
	public Image player1ConnectionInfo;
	public Image player2ConnectionInfo;

	public GameObject readyButton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		updatePlayerConnectionStatus();

		if(AHServer.singleton.areBothPlayersConnected())
		{
			readyButton.SetActive(true);
		}

		if(AHServer.singleton.areBothVoicesLoaded())
		{
			SceneManager.LoadScene("gameplay");
		}
	}

	void updatePlayerConnectionStatus()
	{
		if (AHServer.singleton.playerConnections[0] == null)
		{
			player1ConnectionInfo.color = Color.red;
		}
		else
		{
			player1ConnectionInfo.color = Color.green;
		}

		if (AHServer.singleton.playerConnections[1] == null)
		{
			player2ConnectionInfo.color = Color.red;
		}
		else
		{
			player2ConnectionInfo.color = Color.green;
		}
	}

	public void startVoiceRecord()
	{
		AHServer.singleton.sendStartRecordingMessage();
	}
}
