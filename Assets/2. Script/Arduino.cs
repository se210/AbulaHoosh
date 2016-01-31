using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class Arduino : MonoBehaviour {

    SerialPort sp = new SerialPort("COM3", 9600);
    
    private int buttonCount = 0;
    
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
                Debug.Log(sp.ReadByte());
            }
            catch (System.Exception)
            {
               
            }
        }
	}
}
