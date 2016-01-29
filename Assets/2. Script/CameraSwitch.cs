using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {
    #region public variable
    public GameObject mainCamera;
    public GameObject backCamera;
    #endregion

    #region private variable
    private Camera _mainCamera;
    private Camera _backCamera;
    #endregion

    // Use this for initialization
    void Start () {
        _mainCamera = mainCamera.GetComponent<Camera>();
        _backCamera = backCamera.GetComponent<Camera>();
        _mainCamera.enabled = true;
        _backCamera.enabled = false;       
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKey(KeyCode.Q))
        {
            _mainCamera.enabled = true;
            _backCamera.enabled = false;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            _mainCamera.enabled = false;
            _backCamera.enabled = true;
        }

	}
}
