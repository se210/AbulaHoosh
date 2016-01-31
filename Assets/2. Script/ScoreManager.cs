using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public float maxHealth = 100f;
    public float curPlayer1_Health = 0f;
    public float curPlayer2_Health = 0f;
    public float temp;
    public GameObject player1HealthBar;
    public GameObject player2HealthBar;
     public GameObject sndManager;

    private ScoreManager _scoreManager;
    private SoundManager _soundManager;

    private int _gamePhase = 7;
    private int _currentPhase;
    private int _player1WinCount = 0;
    private int _player2WinCount = 0;
    private bool _isPlayer1Win;
    private bool _isPlayer2Win;
   
    private bool[] nFlag = {false,false,false,false,false, false,false };

    float addpoint;

    void Start () {
        addpoint = temp;
        _scoreManager = GetComponent<ScoreManager>();
        _soundManager = sndManager.GetComponent<SoundManager>();
        _currentPhase = 1;
        _isPlayer2Win = false;
        _isPlayer1Win = false;
    }

	void Update () {
        Debug.Log(_currentPhase);
      switch (_currentPhase) {
            case 1:
                if (GameManager.singleton.useShake)
                {
                    GameManager.singleton.useShake = false;
                }
				GetArduinoData();
				if (nFlag[0] == false)
				{
					_soundManager.SendMessage("Play", "Grab1");
					nFlag[0] = true;
				}
                break;
           case 2:
                if (nFlag[1] == false)
                {
                    _soundManager.SendMessage("Play", "Bridge");
                    nFlag[1] = true;
                }
				StartCoroutine("WaitBrige");
				ResetHealth();
                break;

            case 3:
                if (GameManager.singleton.useShake == false)
                {
                    GameManager.singleton.useShake = true;
                   
                }
                GetAndroidData();
                if (nFlag[2] == false)
                {
                    _soundManager.SendMessage("Play", "Shake1");
                    nFlag[2] = true;
                }
                break;

            case 4:
                if (nFlag[3] == false)
                {
                    _soundManager.SendMessage("Play", "Bridge");
                    nFlag[3] = true;
                }
				StartCoroutine("WaitBrige");
				ResetHealth();
                break;

            case 5:
                if (GameManager.singleton.useShake)
                {
                    GameManager.singleton.useShake = false;
                }
             
                    GetArduinoData();
                    if (nFlag[4] == false)
                    {
                        _soundManager.SendMessage("Play", "Grab2");
                        nFlag[4] = true;
                    }
              
                break;

            case 6:
                if (nFlag[5] == false)
                {
                    _soundManager.SendMessage("Play", "Bridge");
                    nFlag[5] = true;
                }
				StartCoroutine("WaitBrige");
				ResetHealth();
                break;

            case 7:
                if (GameManager.singleton.useShake == false)
                {
                    GameManager.singleton.useShake = true;
                }
                GetAndroidData();
                if (nFlag[6] == false)
                {
                    _soundManager.SendMessage("Play", "Shake2");
                    nFlag[6] = true;
                }
                break;
        }
	}

    void Winner()
    {
        _currentPhase++;
    }
    IEnumerator WaitBrige()
    { 
        yield return new WaitForSeconds(9f);
        _currentPhase++;
        StopCoroutine("WaitBrige");

    }
    void ResetHealth()
    {
        curPlayer1_Health = 0f;
        curPlayer2_Health = 0f;
        Player1_SetHealthBar(0.0f);
        Player2_SetHealthBar(0.0f);
        _isPlayer2Win = false;
        _isPlayer1Win = false;
        GameManager.singleton.numGrab[0] = 0;
        GameManager.singleton.numGrab[1] = 0;
    }

    void GetAndroidData()
    {
		int player1ShakerPoint = GameManager.singleton.numShake[0];
		int player2ShakerPoint = GameManager.singleton.numShake[1];
        if (player1ShakerPoint > 0)
        {
            Player1_IncreaseHealth(player1ShakerPoint/3.0f);
        }
        if(player2ShakerPoint > 0)
        {
            Player2_IncreaseHealth(player2ShakerPoint /3.0f);
        }
    }

	void GetArduinoData()
	{
		int player1GrabPoint = GameManager.singleton.numGrab[0];
        Debug.Log("arduino Data" + player1GrabPoint);
		int player2GrabPoint = GameManager.singleton.numGrab[1];
        Debug.Log("arduino Data" + player2GrabPoint );
        if (player1GrabPoint > 0)
		{
			Player1_SetHealthBar(player1GrabPoint/50.0f);
		}
		if(player2GrabPoint > 0)
		{
			Player2_SetHealthBar(player2GrabPoint/50.0f);
		}
	}

    void Player1_SetHealthBar(float myHealth)
    {
        player1HealthBar.transform.localScale = new Vector3(player1HealthBar.transform.localScale.x,
            Mathf.Min(myHealth, 1.0f), player1HealthBar.transform.localScale.z);

        if(myHealth>1.0f){
            if (_isPlayer1Win == false && _isPlayer2Win == false)
            {
                Debug.Log("you player1");
                _isPlayer1Win = true;
                _player1WinCount++;
                Winner();
            }
        }
    }

    public void Player1_IncreaseHealth(float num)
    {
        if (curPlayer1_Health < 100.0f)
        {
            curPlayer1_Health += num;
            float cal_health = curPlayer1_Health / maxHealth;
            Player1_SetHealthBar(cal_health);
        }

    }

    public void Player2_IncreaseHealth(float num)
    {
        if (curPlayer2_Health < 100.0f)
        {
            curPlayer2_Health += num;
            float cal_health = curPlayer2_Health / maxHealth;
            Player2_SetHealthBar(cal_health);
        }
        
    }

    public void Player2_SetHealthBar(float myHealth)
    {
        player2HealthBar.transform.localScale = new Vector3(player2HealthBar.transform.localScale.x, 
			Mathf.Min(myHealth, 1.0f), player2HealthBar.transform.localScale.z);

        if (myHealth > 1.0f)
        {
            if (_isPlayer1Win == false && _isPlayer2Win == false)
            {
                Debug.Log("you player1");
                _isPlayer2Win = true;
                _player2WinCount++;
                Winner(); 
            }
        }
    }
}
