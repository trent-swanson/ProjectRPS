using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RPSLogic
{

    // Array for easy Rock, Paper, Scissors, Block and Nothing logic of our game.
    // If used correctly, finding the number at index [playerOneMove, playerTwoMove]
    // will show which player one or if it was a draw.s
    [HideInInspector]
    public static int[,] OutCome = new int[5,5] { 
                                                  {0,2,1,0,2}, 
                                                  {1,0,2,0,2},
                                                  {0,0,0,0,0},
                                                  {2,1,0,0,2},
                                                  {1,1,1,0,0}
                                                };



	public static int winner;

	// public static int ReturnOutcome
    //
    // parametres:
    // int playerOneAction is going to be 0-4 inclusive.
    // 0 = Attack.
    // 1 = Lunge.
    // 2 = Parry.
    // 3 = Block.
    // 4 = Nothing.
    // int playerTwoAction is also going to be 0-4 inclusive, refer to notation above.
    // returns the outcome of a round from the actions denoted by the parameters.
    //
    // returns 0 if it is a draw, or someone blocks.
    // returns 1 if playerOne is the winner of the round.
    // returns 2 if playerTwo is the winner of the round.
    public static int ReturnOutcome(int playerOneAction, int PlayerTwoAction)
    {
        return (OutCome[playerOneAction, PlayerTwoAction]);
    }
}
