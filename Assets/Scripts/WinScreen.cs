using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour {

	public Image background;
	public Sprite player1, player2;

	void Start() {
		if (RPSLogic.winner == 1) {
			background.sprite = player1;
		} else {
			background.sprite = player2;
		}
	}
}
