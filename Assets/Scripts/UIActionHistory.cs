using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIActionHistory : MonoBehaviour {

	TurnManager turnManager;
	public GameObject[] p1Actions;
	public GameObject[] p2Actions;

	void Start() {
		turnManager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<TurnManager> ();
	}

	public void UpdateActionHistory() {
		for (int i = 0; i < turnManager.playerOneLastActions.Count; i++) {
			p1Actions [i].SetActive (true);
			if (turnManager.playerOneLastActions[i] == 0) {
				p1Actions [i].transform.GetChild (0).GetComponent<Text>().text = "Attack";
			} else if (turnManager.playerOneLastActions[i] == 1) {
				p1Actions [i].transform.GetChild (0).GetComponent<Text>().text = "Lunge";
			} else if (turnManager.playerOneLastActions[i] == 2) {
				p1Actions [i].transform.GetChild (0).GetComponent<Text>().text = "Parry";
			} else if (turnManager.playerOneLastActions[i] == 3) {
				p1Actions [i].transform.GetChild (0).GetComponent<Text>().text = "Block";
			} else if (turnManager.playerOneLastActions[i] == 4) {
				p1Actions [i].transform.GetChild (0).GetComponent<Text>().text = "Nothing";
			}
		}

		for (int i = 0; i < turnManager.playerTwoLastActions.Count; i++) {
			p2Actions [i].SetActive (true);
			if (turnManager.playerTwoLastActions[i] == 0) {
				p2Actions [i].transform.GetChild (0).GetComponent<Text>().text = "Attack";
			} else if (turnManager.playerTwoLastActions[i] == 1) {
				p2Actions [i].transform.GetChild (0).GetComponent<Text>().text = "Lunge";
			} else if (turnManager.playerTwoLastActions[i] == 2) {
				p2Actions [i].transform.GetChild (0).GetComponent<Text>().text = "Parry";
			} else if (turnManager.playerTwoLastActions[i] == 3) {
				p2Actions [i].transform.GetChild (0).GetComponent<Text>().text = "Block";
			} else if (turnManager.playerTwoLastActions[i] == 4) {
				p2Actions [i].transform.GetChild (0).GetComponent<Text>().text = "Nothing";
			}
		}
	}
}
