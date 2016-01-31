using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class Arduino : MonoBehaviour {

	public string serialPortName;
	SerialPort sp;
    
    private int buttonCount = 0;
    private int data = 0;
    
	// Use this for initialization
	void Start () {
		sp = new SerialPort(serialPortName, 9600);
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
					GameManager.singleton.numGrab[0]++;
                }
                else if(data == 66)
				{
					GameManager.singleton.numGrab[1]++;
                }
            }
            catch (System.Exception)
            {
               
            }
        }
	}
}
