using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int MAX_PLAYER_HEALTH;
    public float MAX_TURN_TIME;
    private int playerOneHealth;
    private int playerTwoHealth;
    private float turnTimer;
    private List<int> playerOneLastActions;
    private List<int> playerTwoLastActions;
}
