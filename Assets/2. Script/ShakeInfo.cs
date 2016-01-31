using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShakeInfo : MonoBehaviour {

	public Text player1ShakeInfo;
	public Text player2ShakeInfo;

	int player1ShakeCount = 0;
	int player2ShakeCount = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		player1ShakeCount += GameManager.singleton.numShake[0];
		player2ShakeCount += GameManager.singleton.numShake[1];
		player1ShakeInfo.text = string.Format("Player1 Shake Count: {0:D}, Rate: {1:F}\nGrab Rate: {2:F}", 
			player1ShakeCount, GameManager.singleton.shakeRate[0],
			GameManager.singleton.grabRate[0]
		);
		player2ShakeInfo.text = string.Format("Player2 Shake Count: {0:D}, Rate: {1:F}\nGrab Rate: {2:F}", 
			player2ShakeCount, GameManager.singleton.shakeRate[1],
			GameManager.singleton.grabRate[1]
		);
	}
}
