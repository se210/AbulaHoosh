using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public float maxHealth = 100f;
    public float curPlayer1_Health = 0f;
    public float curPlayer2_Health = 0f;

    public GameObject player1HealthBar;
    public GameObject player2HealthBar;

    public GameObject arduinoConnection;

    private Arduino serial; 
    // Use this for initialization
    void Start () {
        serial = arduinoConnection.GetComponent<Arduino>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Player1_IncreaseHealth();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Player2_IncreaseHealth();
        }
	}

    void Player1_IncreaseHealth()
    {
        if (curPlayer1_Health < 100.0f)
        {
            curPlayer1_Health += 5;
            float cal_health = curPlayer1_Health / maxHealth;
            Debug.Log(curPlayer1_Health);
            Player1_SetHealthBar(cal_health);
        }
    }

    public void Player1_SetHealthBar(float myHelath)
    {
        player1HealthBar.transform.localScale = new Vector3(player1HealthBar.transform.localScale.x, myHelath, player1HealthBar.transform.localScale.z);

    }

    void Player2_IncreaseHealth()
    {
        if (curPlayer2_Health < 100.0f)
        {
            curPlayer2_Health += 5;
            float cal_health = curPlayer2_Health / maxHealth;
            Debug.Log(curPlayer2_Health);
            Player2_SetHealthBar(cal_health);
        }
    }
    public void Player2_SetHealthBar(float myHelath)
    {
        player2HealthBar.transform.localScale = new Vector3(player2HealthBar.transform.localScale.x, myHelath, player2HealthBar.transform.localScale.z);

    }

}
