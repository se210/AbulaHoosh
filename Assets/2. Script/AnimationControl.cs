using UnityEngine;
using System.Collections;

public class AnimationControl : MonoBehaviour {

    public GameObject player2;

    private Animator anim;

    int shake;
    int grab;
    int idle;
    int follow;
	// Use this for initialization
	void Start () {
        anim = player2.GetComponent<Animator>();
	}
	
	void Update () {

        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (Input.GetKey(KeyCode.Alpha1))
        {
            anim.SetInteger("IsFollowMe", 0);
            anim.SetInteger("IsGrab", 0);
            anim.SetInteger("IsShake", 0);
        } else if (Input.GetKey(KeyCode.Alpha2))
        {
            anim.SetInteger("IsShake", 2);
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            anim.SetInteger("IsGrab", 2);
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            anim.SetInteger("IsFollowMe", 2);
        }
	}

    public void Idle()
    {
        anim.SetInteger("IsShake",0);
    }

    public void Shake()
    {
        anim.SetInteger("IsShake", 2);
    }

    public void Grab()
    {
        anim.SetInteger("IsGrab", 2);
    }
    
    public void FollowMe()
    {
        anim.SetInteger("IsFollowMe", 2);
    }

}
