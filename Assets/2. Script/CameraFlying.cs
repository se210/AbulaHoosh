using UnityEngine;
using System.Collections;

public class CameraFlying : MonoBehaviour {

    #region animation, transform value
    private Animation _anim;
    private Vector3 _fristPosition;
    private Vector3 _rotation;
    #endregion

    void Start()
    {
        _anim = GetComponent<Animation>();
        _fristPosition = transform.position;
        _rotation = transform.rotation.eulerAngles;
    }

	void Update () {
        if (Input.GetKey(KeyCode.F))
        {
            _anim.Play();
        }
        else if (Input.GetKey(KeyCode.G))
        {
            transform.position= new Vector3(_fristPosition.x, _fristPosition.y, _fristPosition.z);
            transform.rotation = Quaternion.Euler(_rotation.x, _rotation.y, _rotation.z);
        }
	}
}
