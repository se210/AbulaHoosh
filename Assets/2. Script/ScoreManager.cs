using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public float maxHealth = 100f;
    public float curPlayer1_Health = 0f;
    public float curPlayer2_Health = 0f;
    public float temp;
    public GameObject player1HealthBar;
    public GameObject player2HealthBar;

    float addpoint;

    public AHServer ahServer;
    private int player1ShakerPoint = 0;
    private int player2ShakerPoint = 0;

    void Start () {
        addpoint = temp;
    }

	void Update () {
        GetAndroidData();     
	}

    void GetAndroidData()
    {
		player1ShakerPoint = GameManager.singleton.numShake[0];
		player2ShakerPoint = GameManager.singleton.numShake[1];
        if (player1ShakerPoint > 0)
        {
            Player1_IncreaseHealth(player1ShakerPoint/3.0f);
        }
        if(player2ShakerPoint > 0)
        {
            Player2_IncreaseHealth(player2ShakerPoint /3.0f);
        }
    }

    public void Player1_IncreaseHealth(float num)
    {
        if (curPlayer1_Health < 100.0f)
        {
            curPlayer1_Health += num;
            //curPlayer1_Health += addpoint;
            float cal_health = curPlayer1_Health / maxHealth;
            Player1_SetHealthBar(cal_health);
        }
    }

     void Player1_SetHealthBar(float myHelath)
    {
        player1HealthBar.transform.localScale = new Vector3(player1HealthBar.transform.localScale.x, 
                                                            myHelath, player1HealthBar.transform.localScale.z);
    }

    public void Player2_IncreaseHealth(float num)
    {
        if (curPlayer2_Health < 100.0f)
        {
            curPlayer2_Health += num;
            float cal_health = curPlayer2_Health / maxHealth;
            Debug.Log(curPlayer2_Health);
            Player2_SetHealthBar(cal_health);
        }
    }

    public void Player2_SetHealthBar(float myHelath)
    {
        player2HealthBar.transform.localScale = new Vector3(player2HealthBar.transform.localScale.x, 
                                                            myHelath, player2HealthBar.transform.localScale.z);
    }
}
