using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPSLogic : MonoBehaviour
{
    [HideInInspector]
    public int[,] OutCome = new int[5,5] { {0,2,1,0,2 }, 
                                           {1,0,2,0,2 },
                                           {2,1,0,0,2 },
                                           {0,0,0,0,0 },
                                           {1,1,1,0,0 }
                                         };

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public int ReturnOutcome(int playerOneAction, int PlayerTwoAction)
    {
        return (OutCome[playerOneAction, PlayerTwoAction]);
    }
}
