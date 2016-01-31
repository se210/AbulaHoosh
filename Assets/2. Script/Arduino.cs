using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class Arduino : MonoBehaviour {

    public ScoreManager scrMgr;
    SerialPort sp = new SerialPort("COM3", 9600);
    
    private int buttonCount = 0;
    private int data = 0;
    
	// Use this for initialization
	void Start () {
        if (sp.IsOpen)
        {
            sp.Close();
        }
        else {
            sp.Open();
            sp.ReadTimeout = 1;
        }
	}

    public int GetData()
    {
        return buttonCount;
    }
    void SetData(int temp)
    {
        buttonCount = temp;
    }

    void Update() { 
        if (sp.IsOpen)
        {
            try
            {
                data = sp.ReadByte();
                if(data == 65)
                {
                    scrMgr.GetComponent<ScoreManager>().Player1_IncreaseHealth(2.0f);
                }
                else if(data == 66)
                {
                    scrMgr.GetComponent<ScoreManager>().Player2_IncreaseHealth(2.0f);
                }
            }
            catch (System.Exception)
            {
               
            }
        }
	}
}
