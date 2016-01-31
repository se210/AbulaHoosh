using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayAgain : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Image>().enabled = false;
	}
	
	// Update is called once per frame
	public void ShowPlayAgain()
    {
        Application.LoadLevel(0);
    }
}
