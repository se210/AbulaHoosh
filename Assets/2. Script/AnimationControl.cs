using UnityEngine;
using System.Collections;

public class AnimationControl : MonoBehaviour {

    public Animator anim;
	public int playerNum;

    int shake;
    int grab;
    int idle;
    int follow;

	float startTime;

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
		// Shaking animation control
		if (GameManager.singleton.useShake)
		{
			float shakeRate = GameManager.singleton.shakeRate[playerNum];
			if (shakeRate > 0.05f)
			{
				anim.speed = Mathf.Max(shakeRate / 20.0f, 0.5f);
				Shake();
				startTime = Time.time;
			}
			else
			{
				anim.speed = Mathf.Lerp(anim.speed, 1.0f, (Time.time - startTime)/0.3f);
				Idle();
			}
		}
		// Grabbing animation control
		else
		{
			float grabRate = GameManager.singleton.grabRate[playerNum];
			if (grabRate > 0.05f)
			{
				anim.speed = Mathf.Max(grabRate / 3.0f, 0.5f);
				Grab();
				startTime = Time.time;
			}
			else
			{
				anim.speed = Mathf.Lerp(anim.speed, 1.0f, (Time.time - startTime)/0.3f);
				Idle();
			}
		}
	}

    public void Idle()
    {
		anim.SetInteger("IsShake",0);
		anim.SetInteger("IsGrab", 0);
		anim.SetInteger("IsFollowMe", 0);
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
