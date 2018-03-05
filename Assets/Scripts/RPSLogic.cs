using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RPSLogic
{
    [HideInInspector]
    public static int[,] OutCome = new int[5,5] { {0,2,1,0,2 }, 
                                           {1,0,2,0,2 },
                                           {2,1,0,0,2 },
                                           {0,0,0,0,0 },
                                           {1,1,1,0,0 }
                                         };



    public static int ReturnOutcome(int playerOneAction, int PlayerTwoAction)
    {
        return (OutCome[playerOneAction, PlayerTwoAction]);
    }
}
