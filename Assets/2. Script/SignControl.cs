using UnityEngine;
using System.Collections;

public class SignControl : MonoBehaviour {

    private MeshRenderer _shakeRender;
    public GameObject shakeIcon;
	// Use this for initialization
	void Start () {
        _shakeRender = shakeIcon.GetComponent<MeshRenderer>();
      //  _shakeRender.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(FadeTo(0.0f, 1.0f));
        }
	}

    IEnumerator FadeTo(float aValue, float aTime)
    {
        Debug.Log("here?");
        float alpha = _shakeRender.material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            _shakeRender.material.color = newColor;
            yield return null;
        }
    }


}
