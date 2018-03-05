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

    // ResolveTurn Function:
    // Parametres: playerOne (the choice of the left player) and playerTwo (the choice of the right player)
    // Return int:
      // 0 = this round was a draw
      // 1 = playerOne won this round
      // 2 = playerTwo won this round
      // 3 = ERROR (ignore call)
    public int ResolveTurn(PlayerChoice playerOne, PlayerChoice playerTwo)
    {
        /* PLAYER ONE ROCK*/

        // Player One = ROCK && Player Two = ROCK
        if (playerOne == PlayerChoice.ROCK && playerTwo == PlayerChoice.ROCK)
        {
            //DRAW
            return 0;
        }

        // Player One = ROCK && Player Two = PAPER
        if (playerOne == PlayerChoice.ROCK && playerTwo == PlayerChoice.PAPER)
        {
            // playerOne loses round
            return 2;
        }

        // Player One = ROCK && Player Two = SCISSORS
        if (playerOne == PlayerChoice.ROCK && playerTwo == PlayerChoice.SCISSORS)
        {
            // playerOne wins round
            return 1;
        }

        // Player One = ROCK && Player Two = NOTHING
        if (playerOne == PlayerChoice.ROCK && playerTwo == PlayerChoice.NOTHING)
        {
            // playerOne wins round
            return 1;
        }

        /* PLAYER ONE PAPER*/

        // Player One = PAPER && Player Two = ROCK
        if (playerOne == PlayerChoice.PAPER && playerTwo == PlayerChoice.ROCK)
        {
            // playerOne wins round
            return 1;
        }

        // Player One = PAPER && Player Two = PAPER
        if (playerOne == PlayerChoice.PAPER && playerTwo == PlayerChoice.ROCK)
        {
            // DRAW
            return 0;
        }

        // Player One = PAPER && Player Two = SCISSORS
        if (playerOne == PlayerChoice.PAPER && playerTwo == PlayerChoice.SCISSORS)
        {
            // playerOne loses round
            return 2;
        }

        // Player One = PAPER && Player Two = NOTHING
        if (playerOne == PlayerChoice.PAPER && playerTwo == PlayerChoice.NOTHING)
        {
            // playerOne wins round
            return 1;
        }

        /* PLAYER ONE SCISSORS*/

        // Player One = SCISSORS && Player Two = ROCK
        if (playerOne == PlayerChoice.SCISSORS && playerTwo == PlayerChoice.ROCK)
        {
            // playerOne loses round
            return 2;
        }

        // Player One = SCISSORS && Player Two = PAPER
        if (playerOne == PlayerChoice.SCISSORS && playerTwo == PlayerChoice.PAPER)
        {
            // playerOne wins round
            return 1;
        }

        // Player One = SCISSORS && Player Two = SCISSORS
        if (playerOne == PlayerChoice.SCISSORS && playerTwo == PlayerChoice.SCISSORS)
        {
            // DRAW
            return 0;
        }

        // Player One = SCISSORS && Player Two = NOTHING
        if (playerOne == PlayerChoice.SCISSORS && playerTwo == PlayerChoice.NOTHING)
        {
            // playerOne wins round
            return 1;
        }

        /* PLAYER ONE NOTHING*/

        // Player One = NOTHING && Player Two = ROCK
        if (playerOne == PlayerChoice.NOTHING && playerTwo == PlayerChoice.ROCK)
        {
            // playerOne loses round
            return 2;
        }

        // Player One = NOTHING && Player Two = PAPER
        if (playerOne == PlayerChoice.NOTHING && playerTwo == PlayerChoice.PAPER)
        {
            // playerOne loses round
            return 2;
        }

        // Player One = NOTHING && Player Two = SCISSORS
        if (playerOne == PlayerChoice.NOTHING && playerTwo == PlayerChoice.SCISSORS)
        {
            // playerOne loses round
            return 2;
        }

        // Player One = NOTHING && Player Two = NOTHING
        if (playerOne == PlayerChoice.NOTHING && playerTwo == PlayerChoice.NOTHING)
        {
            // DRAW
            return 0;
        }

        // this return should never be called.
        return 3;
    }
}
