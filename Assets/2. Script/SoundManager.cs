using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public AudioClip[] audioClip;
    public string[] audioName;
    public bool clipFound;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Play(string clipName)
    {
        for (int i=0; i< audioName.Length; i++)
        {
            if(clipName == audioName[i])
            {
                gameObject.GetComponent<AudioSource>().clip = audioClip[i];
                gameObject.GetComponent<AudioSource>().Play();
                clipFound = true;
                break;
            }
            else
            {
                clipFound = false;
            }
        }
        if (!clipFound)
        {
            Debug.Log("audio missing");
        }

    }
}
