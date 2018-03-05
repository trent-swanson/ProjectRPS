using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

    [HideInInspector]
    public enum PlayerChoice
    {
        ATTACK = 0,
        LUNGE,
        PARRY,
        BLOCK,
        NOTHING,
        ITEM_COUNT
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (turnTimer >= 0 || (playerOneNextAction != 0 && playerTwoNextAction != 0)) {
            turnTimer = MAX_TURN_TIME;
            //call the RPSlogics functionality to get what happened
        }
        else {
            //check for player inputs and store them
            turnTimer -= Time.deltaTime;
        }
	}

    public int MAX_PLAYER_HEALTH;
    public float MAX_TURN_TIME;
    private float turnTimer;
    private int playerOneHealth;
    private int playerTwoHealth;
    private List<int> playerOneLastActions;
    private List<int> playerTwoLastActions;
    private int playerOneNextAction;
    private int playerTwoNextAction;
    private int turnNumber;
}
