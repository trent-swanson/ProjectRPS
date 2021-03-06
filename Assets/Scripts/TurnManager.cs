﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        timerBetweenTurns = 0;
        playerOneNextAction = (int)PlayerChoice.NOTHING;
        playerTwoNextAction = (int)PlayerChoice.NOTHING;
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {

        if (timerBetweenTurns > 0)
        {
            if ((timerBetweenTurns < TIME_BETWEEN_TURNS * 0.75) && (lastTookDamage == 1))
            {
                Player1.GetComponent<SpriteRenderer>().sprite = spritesP1[(int)PlayerChoice.ITEM_COUNT];
				if (!sound.isPlaying && !hitSound) {
					hitSound = true;
					sound.loop = false;
					sound.PlayOneShot (sound.clip);
				}
            }
            if ((timerBetweenTurns < TIME_BETWEEN_TURNS * 0.75) && (lastTookDamage == 2))
            {
                Player2.GetComponent<SpriteRenderer>().sprite = spritesP2[(int)PlayerChoice.ITEM_COUNT];
				if (!sound.isPlaying && !hitSound) {
					hitSound = true;
					sound.loop = false;
					sound.PlayOneShot (sound.clip);
				}
            }
            timerBetweenTurns -= Time.deltaTime;
            turnTimer = MAX_TURN_TIME;
        }

        if(timerBetweenTurns <= 0)
        {
            //check if either player has zero health
            if (playerOneHealth < 1) {
                //set the winner to player 2
                RPSLogic.winner = 2;
                //change scene
                SceneManager.LoadScene("winScreen");
            }
            if (playerTwoHealth < 1) {
                //set the winner to player 1
                RPSLogic.winner = 1;
                //change scene
                SceneManager.LoadScene("winScreen");
            }

            if (turnTimer < 0 || (playerOneNextAction != (int)PlayerChoice.NOTHING && playerTwoNextAction != (int)PlayerChoice.NOTHING)) {
                turnTimer = 0;
                //call the RPSlogics functionality to get what happened
                if ((RPSLogic.ReturnOutcome(playerOneNextAction, playerTwoNextAction)) == 2) {
                    playerTwoHealth -= 1;
                    transform.GetComponent<UIHealthBar>().UpdateHealth();
                    lastTookDamage = 2;
                }
                else if ((RPSLogic.ReturnOutcome(playerOneNextAction, playerTwoNextAction)) == 1) {
                    playerOneHealth -= 1;
                    transform.GetComponent<UIHealthBar>().UpdateHealth();
                    lastTookDamage = 1;
                }
                else {
                    lastTookDamage = 0;
                }

                //set the player sprites to the players next actions
                if (Player1 != null)
                    Player1.GetComponent<SpriteRenderer>().sprite  = spritesP1[playerOneNextAction];
                if (Player2 != null)
                    Player2.GetComponent<SpriteRenderer>().sprite  = spritesP2[playerTwoNextAction];

                //reset the playes last actions and store their previous actions
                playerOneLastActions.Add(playerOneNextAction);
                playerOneNextAction = (int)PlayerChoice.NOTHING;
                playerTwoLastActions.Add(playerTwoNextAction);
                playerTwoNextAction = (int)PlayerChoice.NOTHING;
                //set the timer for the 'animations' 
                timerBetweenTurns = TIME_BETWEEN_TURNS;
				hitSound = false;
                //update the visible list of the actions last peformed by the 
                //two players once they've selected their moves for the current turn
                if(canvas != null)
                    canvas.GetComponent<UIActionHistory>().UpdateActionHistory();
            }
            else
            {
                //reset the player sprites to the idle
                if (Player1 != null) {
                    if (Player1.GetComponent<SpriteRenderer>().sprite  != null)
                        Player1.GetComponent<SpriteRenderer>().sprite  = spritesP1[(int)PlayerChoice.NOTHING];
                }
                if (Player2 != null) {
                    if (Player2.GetComponent<SpriteRenderer>().sprite  != null)
                        Player2.GetComponent<SpriteRenderer>().sprite  = spritesP2[(int)PlayerChoice.NOTHING];
                }
                //right at the start of the turn display the player action wheel
                if (turnTimer == MAX_TURN_TIME) {
                    if (canvas != null)
                        canvas.GetComponent<UIActionHistory>().OpenPlayerOptions();
                }
                //check for player inputs and store them
                if (playerOneNextAction == (int)PlayerChoice.NOTHING)
                {
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        if (playerOneLastActions.Count < 1) { 
                            playerOneNextAction = (int)PlayerChoice.PARRY;
                        canvas.GetComponent<UIActionHistory>().ClosePlayerOptions(1);
                        }
                    else if (playerOneLastActions[playerOneLastActions.Count - 1] != (int)PlayerChoice.PARRY) { 
                            playerOneNextAction = (int)PlayerChoice.PARRY;
                        canvas.GetComponent<UIActionHistory>().ClosePlayerOptions(1);
                        }
                    }
                    else if (Input.GetKeyDown(KeyCode.W))
                    {
                        if (playerOneLastActions.Count < 1) {
                            playerOneNextAction = (int)PlayerChoice.ATTACK;
                        canvas.GetComponent<UIActionHistory>().ClosePlayerOptions(1);
                        }
                    else if (playerOneLastActions[playerOneLastActions.Count - 1] != (int)PlayerChoice.ATTACK) { 
                            playerOneNextAction = (int)PlayerChoice.ATTACK;
                        canvas.GetComponent<UIActionHistory>().ClosePlayerOptions(1);
                        }
                    }
                    else if (Input.GetKeyDown(KeyCode.D))
                    {
                        if (playerOneLastActions.Count < 1) {
                            playerOneNextAction = (int)PlayerChoice.LUNGE;
                        canvas.GetComponent<UIActionHistory>().ClosePlayerOptions(1);
                        }
                    else if (playerOneLastActions[playerOneLastActions.Count - 1] != (int)PlayerChoice.LUNGE) {
                        playerOneNextAction = (int)PlayerChoice.LUNGE;
                        canvas.GetComponent<UIActionHistory>().ClosePlayerOptions(1);
                        }
                    }
                    else if (Input.GetKeyDown(KeyCode.S))
                    {
                        if (playerOneLastActions.Count < 1) {
                            playerOneNextAction = (int)PlayerChoice.BLOCK;
                        canvas.GetComponent<UIActionHistory>().ClosePlayerOptions(1);
                        }
                    else if (playerOneLastActions[playerOneLastActions.Count - 1] != (int)PlayerChoice.BLOCK) {
                        playerOneNextAction = (int)PlayerChoice.BLOCK;
                        canvas.GetComponent<UIActionHistory>().ClosePlayerOptions(1);
                        }
                    }
                }
                if (playerTwoNextAction == (int)PlayerChoice.NOTHING)
                {
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        if (playerTwoLastActions.Count < 1) {
                            playerTwoNextAction = (int)PlayerChoice.PARRY;
                        canvas.GetComponent<UIActionHistory>().ClosePlayerOptions(2);
                        }
                    else if (playerTwoLastActions[playerTwoLastActions.Count - 1] != (int)PlayerChoice.PARRY)
                    {
                        playerTwoNextAction = (int)PlayerChoice.PARRY;
                        canvas.GetComponent<UIActionHistory>().ClosePlayerOptions(2);
                    }
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        if (playerTwoLastActions.Count < 1) {
                            playerTwoNextAction = (int)PlayerChoice.ATTACK;
                        canvas.GetComponent<UIActionHistory>().ClosePlayerOptions(2);
                        }
                    else if (playerTwoLastActions[playerTwoLastActions.Count - 1] != (int)PlayerChoice.ATTACK) {
                        playerTwoNextAction = (int)PlayerChoice.ATTACK;
                        canvas.GetComponent<UIActionHistory>().ClosePlayerOptions(2);
                    }
                    }
                    else if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        if (playerTwoLastActions.Count < 1) {
                            playerTwoNextAction = (int)PlayerChoice.LUNGE;
                            canvas.GetComponent<UIActionHistory>().ClosePlayerOptions(2);
                        }
                        else if (playerTwoLastActions[playerTwoLastActions.Count - 1] != (int)PlayerChoice.LUNGE) {
                            playerTwoNextAction = (int)PlayerChoice.LUNGE;
                            canvas.GetComponent<UIActionHistory>().ClosePlayerOptions(2);
                        }
                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        if (playerTwoLastActions.Count < 1) {
                            playerTwoNextAction = (int)PlayerChoice.BLOCK;
                        canvas.GetComponent<UIActionHistory>().ClosePlayerOptions(2);
                    }
                    else if (playerTwoLastActions[playerTwoLastActions.Count - 1] != (int)PlayerChoice.BLOCK) {
                            playerTwoNextAction = (int)PlayerChoice.BLOCK;
                        canvas.GetComponent<UIActionHistory>().ClosePlayerOptions(2);
                    }
                }
                }
                turnTimer -= Time.deltaTime;
            }
        }
    }

    public int getHealthP1() { return playerOneHealth; }
    public int getHealthP2() { return playerTwoHealth; }
    public float getCurrentTurnTime() { return turnTimer; }

    public AudioSource sound;
    public Canvas canvas;
    public GameObject Player1;
    public GameObject Player2;
    public Sprite[] spritesP1;
    public Sprite[] spritesP2;
    public float MAX_TURN_TIME = 10;
    public float TIME_BETWEEN_TURNS;
    public int MAX_PLAYER_HEALTH;
    public int playerOneNextAction;
    public int playerTwoNextAction;
    public List<int> playerOneLastActions;
    public List<int> playerTwoLastActions;
    private float turnTimer;
    private float timerBetweenTurns;
    private int playerOneHealth;
    private int playerTwoHealth;
    private int turnNumber;
    private int lastTookDamage;
	private bool hitSound = false;
}
