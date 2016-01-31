using UnityEngine;
using System.Collections;

public class MinionAnimControl : MonoBehaviour {
     GameObject[] redMinions;
     GameObject[] blueMinions;
    Animator[] _RedAnims;
    Animator[] _BlueAnims;

    int redCount = 0;
    int blueCount = 0;


    // Use this for initialization
	void Start () {
		
		redMinions = GameObject.FindGameObjectsWithTag("RED_MINION");
		blueMinions = GameObject.FindGameObjectsWithTag("BLUE_MINION");
      
         redCount = redMinions.Length;
		blueCount = blueMinions.Length;

		_RedAnims = new Animator[redCount];
        for (int i = 0; i<redCount; i++)
        {
            _RedAnims[i] = redMinions[i].GetComponent<Animator>();
		}

		_BlueAnims = new Animator[blueCount];
        for (int i = 0; i < blueCount; i++)
        {
            _BlueAnims[i] = blueMinions[i].GetComponent<Animator>();
        }
    }
	
	void Update () {

        if (Input.GetKey(KeyCode.R))
        {
            Reaction();
        }
        else if (Input.GetKey(KeyCode.T))
        {
            Horayab();
        }
        else if (Input.GetKey(KeyCode.Y))
        {
            Idle();
        }
	}
    
    public void Idle()
    {

        for (int i = 0; i < blueCount; i++)
        {
            _BlueAnims[i].SetInteger("IsReaction", 0);
            _BlueAnims[i].SetInteger("IsHoray", 0);
        }
        for (int i = 0; i < redCount; i++)
        {

            _RedAnims[i].SetInteger("IsReaction", 0);
            _RedAnims[i].SetInteger("IsHoray", 0);
        }
       
    }

    public void Reaction()
    {

        for (int i = 0; i < blueCount; i++)
        {
            _BlueAnims[i].SetInteger("IsReaction", 2);
        }

        for (int i = 0; i < redCount; i++)
        {
           _RedAnims[i].SetInteger("IsReaction", 2);
        }
        
    }

    public void Horayab()
    {
        for (int i = 0; i < blueCount; i++)
        {
            _BlueAnims[i].SetInteger("IsHoray", 2);
        }
        for (int i = 0; i < redCount; i++)
        {
            _RedAnims[i].SetInteger("IsHoray", 2);
        }
    }
   
}
