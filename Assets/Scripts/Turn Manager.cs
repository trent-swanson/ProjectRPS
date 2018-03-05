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
        turnTimer = MAX_TURN_TIME;
        playerOneHealth = MAX_PLAYER_HEALTH;
        playerTwoHealth = MAX_PLAYER_HEALTH;
	}
	
	// Update is called once per frame
	void Update () {
        if (turnTimer >= 0 || (playerOneNextAction != (int)PlayerChoice.NOTHING && playerTwoNextAction != (int)PlayerChoice.NOTHING)) {
            turnTimer = MAX_TURN_TIME;
            //call the RPSlogics functionality to get what happened
            if ((RPSLogic.ReturnOutcome(playerOneNextAction, playerTwoNextAction)) == 1) {
                playerTwoHealth -= 1;
            }
            else if ((RPSLogic.ReturnOutcome(playerOneNextAction, playerTwoNextAction)) == 2)
            {
                playerOneHealth -= 1;
            }
            //reset the playes last actions and store their previous actions
            playerOneLastActions.Add(playerOneNextAction);
            playerOneNextAction = (int)PlayerChoice.NOTHING;
            playerTwoLastActions.Add(playerTwoNextAction);
            playerTwoNextAction = (int)PlayerChoice.NOTHING;
        }
        else {
            //check for player inputs and store them
            if (playerOneNextAction == (int)PlayerChoice.NOTHING) {
                if (Input.GetKeyDown(KeyCode.A)) {
                    playerOneNextAction = (int)PlayerChoice.PARRY;
                }
                else if (Input.GetKeyDown(KeyCode.W)) {
                    playerOneNextAction = (int)PlayerChoice.ATTACK;
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    playerOneNextAction = (int)PlayerChoice.LUNGE;
                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    playerOneNextAction = (int)PlayerChoice.BLOCK;
                }
            }
            if (playerTwoNextAction == (int)PlayerChoice.NOTHING)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    playerTwoNextAction = (int)PlayerChoice.PARRY;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    playerTwoNextAction = (int)PlayerChoice.ATTACK;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    playerTwoNextAction = (int)PlayerChoice.LUNGE;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    playerTwoNextAction = (int)PlayerChoice.BLOCK;
                }
            }
            turnTimer -= Time.deltaTime;
        }
	}

    public int MAX_PLAYER_HEALTH;
    public float MAX_TURN_TIME;
    private float turnTimer;
    private int playerOneHealth;
    private int playerTwoHealth;
    public List<int> playerOneLastActions;
    public List<int> playerTwoLastActions;
    public int playerOneNextAction;
    public int playerTwoNextAction;
    private int turnNumber;
}
