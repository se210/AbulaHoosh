using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	static public GameManager singleton;

	public int gamePhase = 0; // Total 4 stages (0-3)
	public bool useShake = true; // which input gains the score in this phase?
	public float[] shakeRate = new float[2] {0, 0};
	public int[] numShake = new int[2] {0, 0};

	// Use this for initialization
	void Start () {
		if (singleton == null)
		{
			singleton = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
