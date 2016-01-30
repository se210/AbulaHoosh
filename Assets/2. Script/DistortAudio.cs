using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class DistortAudio : MonoBehaviour {

    #region Private variables
    public float startingPitch = 1.0f;
    public float maxPitch = 2.0f;
    #endregion

    #region Public variables
    private float count = 1.0f;
    private AudioSource voiceAudio;
    private float volume;
    #endregion

    // Use this for initialization
    void Start () {
        voiceAudio = GetComponent<AudioSource>();
        voiceAudio.pitch = startingPitch;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (count <= maxPitch)
            {
                voiceAudio.pitch = count;
                Debug.Log(voiceAudio);
                count += 0.2f;
            }
            else
            {
                count = maxPitch;
            }
                voiceAudio.Play();
            }
	}
}
