using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    // The TurnManager for the game, which allows access to the playerHealth variables.
    private TurnManager turnManager;
    // Slider that represents the health value of PlayerOne(Left of screen).
    public Slider m_sPlayerOne;
    // Slider that represents the health value of PlayerTwo(Right of screen).
    public Slider m_sPlayerTwo;

	// Use this for initialization
	void Start ()
    {
        turnManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<TurnManager>();

        // Reset the Max values of the sliders to the maximum player health if they exist.
        if (m_sPlayerOne != null)
        {
            m_sPlayerOne.maxValue = turnManager.MAX_PLAYER_HEALTH;
        }
        if (m_sPlayerTwo != null)
        {
            m_sPlayerTwo.maxValue = turnManager.MAX_PLAYER_HEALTH;
        }

        // Incase Unity is ran without these variables being set.
        if (m_sPlayerOne == null)
        {
            Debug.Log("Player One's slider is not assigned");
        }
        if (m_sPlayerTwo == null)
        {
            Debug.Log("Player Two's slider is not assigned");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
       m_sPlayerOne.value = turnManager.getHealthP1(); 
       m_sPlayerTwo.value = turnManager.getHealthP2();
	}
}
