using UnityEngine;
using System.Collections;

public class AnimationControl : MonoBehaviour {

    public Animator anim;
	public int playerNum;

    int shake;
    int grab;
    int idle;
    int follow;
	// Use this for initialization
	void Start () {
	}
	
	void Update () {

//        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

//        if (Input.GetKey(KeyCode.Alpha1))
//        {
//            anim.SetInteger("IsFollowMe", 0);
//            anim.SetInteger("IsGrab", 0);
//            anim.SetInteger("IsShake", 0);
//        } else if (Input.GetKey(KeyCode.Alpha2))
//        {
//            anim.SetInteger("IsShake", 2);
//        }
//        else if (Input.GetKey(KeyCode.Alpha3))
//        {
//            anim.SetInteger("IsGrab", 2);
//        }
//        else if (Input.GetKey(KeyCode.Alpha4))
//        {
//            anim.SetInteger("IsFollowMe", 2);
//        }
		if (AHServer.singleton.shakeRate[playerNum] > 0.05f)
		{
			Shake();
		}
		else
		{
			Idle();
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
