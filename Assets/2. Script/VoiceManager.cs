using UnityEngine;
using System.Collections;

public class VoiceManager : MonoBehaviour {

	public static VoiceManager singleton = null;

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

	public void playVoice(int playerNum)
	{
		string filePath = Application.persistentDataPath + string.Format("/player{0}.wav",playerNum);
		AudioSource aud = gameObject.GetComponent<AudioSource>();
		WWW www = new WWW("file://"+filePath);
		aud.clip = www.audioClip;
		while(aud.clip.loadState != AudioDataLoadState.Loaded);
		aud.Play();
		StartCoroutine(waitForVoice(aud.clip));
	}

	IEnumerator waitForVoice(AudioClip clip)
	{
		yield return new WaitForSeconds(clip.length);
	}
}
