using UnityEngine;
using System.Collections;

public class MinionVoiceControl : MonoBehaviour {

	AudioClip[] playerVoices = new AudioClip[2];
	AudioSource[] audioSources;
	int numVoices = 5;
	float minionPitch = 2.0f;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 2; i++)
		{
			string filePath = Application.persistentDataPath + string.Format("/player{0}.wav",i);
			WWW www = new WWW("file://"+filePath);
			playerVoices[i] = www.audioClip;
			while(playerVoices[i].loadState != AudioDataLoadState.Loaded);
		}

		audioSources = new AudioSource[numVoices];
		for (int i = 0; i < numVoices; i++)
		{
			audioSources[i] = gameObject.AddComponent<AudioSource>();
			audioSources[i].pitch = minionPitch;
			audioSources[i].loop = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	public void playMinionSound(int playerNum)
	{
		for (int i = 0; i < numVoices; i++)
		{
			audioSources[i].clip = playerVoices[playerNum];
			audioSources[i].PlayDelayed(Random.value * 0.1f);
		}
	}

	public void stopMinionSound()
	{
		for (int i = 0; i < numVoices; i++)
		{
			audioSources[i].Stop();
		}
	}
}
