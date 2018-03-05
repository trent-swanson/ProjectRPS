using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPSLogic : MonoBehaviour
{
    [HideInInspector]
    public enum PlayerChoice
    {
        NOTHING = 0,
        ROCK,
        PAPER,
        SCISSORS,
        ITEM_COUNT
    }

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ResolveTurn(PlayerChoice playerOne, PlayerChoice playerTwo)
    {
        /* PLAYER ONE ROCK*/

        // Player One = ROCK && Player Two = ROCK
        if (playerOne == PlayerChoice.ROCK && playerTwo == PlayerChoice.ROCK)
        {
            //DRAW
        }

        // Player One = ROCK && Player Two = PAPER
        if (playerOne == PlayerChoice.ROCK && playerTwo == PlayerChoice.PAPER)
        {
            // playerOne loses round
        }

        // Player One = ROCK && Player Two = SCISSORS
        if (playerOne == PlayerChoice.ROCK && playerTwo == PlayerChoice.SCISSORS)
        {
            // playerOne wins round
        }

        // Player One = ROCK && Player Two = NOTHING
        if (playerOne == PlayerChoice.ROCK && playerTwo == PlayerChoice.NOTHING)
        {
            // playerOne wins round
        }

        /* PLAYER ONE PAPER*/

        // Player One = PAPER && Player Two = ROCK
        if (playerOne == PlayerChoice.PAPER && playerTwo == PlayerChoice.ROCK)
        {
            // playerOne wins round
        }

        // Player One = PAPER && Player Two = PAPER
        if (playerOne == PlayerChoice.PAPER && playerTwo == PlayerChoice.ROCK)
        {
            // DRAW
        }

        // Player One = PAPER && Player Two = SCISSORS
        if (playerOne == PlayerChoice.PAPER && playerTwo == PlayerChoice.SCISSORS)
        {
            // playerOne loses round
        }

        // Player One = PAPER && Player Two = NOTHING
        if (playerOne == PlayerChoice.PAPER && playerTwo == PlayerChoice.NOTHING)
        {
            // playerOne wins round
        }

        /* PLAYER ONE SCISSORS*/

        // Player One = SCISSORS && Player Two = ROCK
        if (playerOne == PlayerChoice.SCISSORS && playerTwo == PlayerChoice.ROCK)
        {
            // playerOne loses round
        }

        // Player One = SCISSORS && Player Two = PAPER
        if (playerOne == PlayerChoice.SCISSORS && playerTwo == PlayerChoice.PAPER)
        {
            // playerOne wins round
        }

        // Player One = SCISSORS && Player Two = SCISSORS
        if (playerOne == PlayerChoice.SCISSORS && playerTwo == PlayerChoice.SCISSORS)
        {
            // DRAW
        }

        // Player One = SCISSORS && Player Two = NOTHING
        if (playerOne == PlayerChoice.SCISSORS && playerTwo == PlayerChoice.NOTHING)
        {
            // playerOne wins round
        }

        /* PLAYER ONE NOTHING*/

        // Player One = NOTHING && Player Two = ROCK
        if (playerOne == PlayerChoice.NOTHING && playerTwo == PlayerChoice.ROCK)
        {
            // playerOne loses round
        }

        // Player One = NOTHING && Player Two = PAPER
        if (playerOne == PlayerChoice.NOTHING && playerTwo == PlayerChoice.PAPER)
        {
            // playerOne loses round
        }

        // Player One = NOTHING && Player Two = SCISSORS
        if (playerOne == PlayerChoice.NOTHING && playerTwo == PlayerChoice.SCISSORS)
        {
            // playerOne loses round
        }

        // Player One = NOTHING && Player Two = NOTHING
        if (playerOne == PlayerChoice.NOTHING && playerTwo == PlayerChoice.NOTHING)
        {
            // DRAW
        }
    }
}
