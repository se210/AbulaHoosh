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

    private int _gamePhase = 4;
    private int _currentPhase;
    private int _player1WinCount = 0;
    private int _player2WinCount = 0;
    private bool _isPlayer1Win;
    private bool _isPlayer2Win;


    float addpoint;

    void Start () {
        addpoint = temp;
        _scoreManager = GetComponent<ScoreManager>();
        _soundManager = sndManager.GetComponent<SoundManager>();
        _currentPhase = 1;
        _isPlayer2Win = false;
        _isPlayer1Win = false;
        Debug.Log(_currentPhase);

    }

	void Update () {
        /*
		if(GameManager.singleton.useShake)
		{
            if (_currentPhase == 2 && _currentPhase<= _gamePhase)
            {
            
                GetAndroidData();
               // _soundManager.SendMessage("Play", "Shake1");
            }
            else if(_currentPhase == 4 && _currentPhase <= _gamePhase)
            {
               
                GetAndroidData();
               // _soundManager.SendMessage("Play", "Shake1");
            }

        }
		else
		{
			
            if (_currentPhase == 1 && _currentPhase <= _gamePhase)
            {
                GetArduinoData();
               // _soundManager.SendMessage("Play", "Grab1");
            }
            else if(_currentPhase == 3 && _currentPhase <= _gamePhase)
            {
                 GetArduinoData();
//_soundManager.SendMessage("Play", "Grab2");
            }
        }
        */
	}

    void ResetHealth()
    {
        curPlayer1_Health = 0f;
        curPlayer2_Health = 0f;
        Player1_SetHealthBar(0.0f);
        Player2_SetHealthBar(0.0f);
        _isPlayer2Win = false;
        _isPlayer1Win = false;
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
		int player2GrabPoint = GameManager.singleton.numGrab[1];
		if (player1GrabPoint > 0)
		{
			Player1_SetHealthBar(player1GrabPoint/50.0f);
		}
		if(player2GrabPoint > 0)
		{
			Player2_SetHealthBar(player2GrabPoint/50.0f);
		}
	}

    void NextPhase()
    {
        Debug.Log(_currentPhase);
        _currentPhase++;
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
                NextPhase();
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
                _player1WinCount++;
                NextPhase();
            }
        }
    }
}
