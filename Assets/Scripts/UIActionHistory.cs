using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIActionHistory : MonoBehaviour {

	TurnManager turnManager;
	public GameObject[] p1Actions;
	public GameObject[] p2Actions;
	public GameObject p1Options;
	public GameObject p2Options;
	public GameObject timerObject;
	public Sprite[] timerSprites;
	int currentTime;
	int savedTime;
	int activeHistoryP1;
	int activeHistoryP2;

	void Start() {
		turnManager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<TurnManager> ();
		currentTime = Mathf.RoundToInt(turnManager.getCurrentTurnTime());
		savedTime = currentTime;
		activeHistoryP1 = 0;
		activeHistoryP2 = 0;
	}

	void Update() {
		currentTime = (int)turnManager.getCurrentTurnTime ();
		if (currentTime < 11) {
			timerObject.GetComponent<Image> ().sprite = timerSprites [currentTime];
		}
	}

	public void UpdateActionHistory() {
		ClosePlayerOptions ();

		if (activeHistoryP1 < 5) {
			p1Actions [activeHistoryP1].SetActive (true);
			activeHistoryP1++;
		}
		if (activeHistoryP2 < 5) {
			p2Actions [activeHistoryP2].SetActive (true);
			activeHistoryP2++;
		}

		int tempCountP1 = activeHistoryP1;
		int tempCountP2 = activeHistoryP2;

		for (int i = turnManager.playerOneLastActions.Count; i > activeHistoryP1; i--) {
			activeHistoryP1--;
			if (turnManager.playerOneLastActions[i] == 0) {
				p1Actions [activeHistoryP1].transform.GetChild (0).GetComponent<Text>().text = "Attack";
			} else if (turnManager.playerOneLastActions[i] == 1) {
				p1Actions [activeHistoryP1].transform.GetChild (0).GetComponent<Text>().text = "Lunge";
			} else if (turnManager.playerOneLastActions[i] == 2) {
				p1Actions [activeHistoryP1].transform.GetChild (0).GetComponent<Text>().text = "Parry";
			} else if (turnManager.playerOneLastActions[i] == 3) {
				p1Actions [activeHistoryP1].transform.GetChild (0).GetComponent<Text>().text = "Block";
			} else if (turnManager.playerOneLastActions[i] == 4) {
				p1Actions [activeHistoryP1].transform.GetChild (0).GetComponent<Text>().text = "Nothing";
			}
		}

		for (int i = turnManager.playerTwoLastActions.Count; i > activeHistoryP2; i--) {
			activeHistoryP2--;
			if (turnManager.playerTwoLastActions[i] == 0) {
				p2Actions [activeHistoryP2].transform.GetChild (0).GetComponent<Text>().text = "Attack";
			} else if (turnManager.playerTwoLastActions[i] == 1) {
				p2Actions [activeHistoryP2].transform.GetChild (0).GetComponent<Text>().text = "Lunge";
			} else if (turnManager.playerTwoLastActions[i] == 2) {
				p2Actions [activeHistoryP2].transform.GetChild (0).GetComponent<Text>().text = "Parry";
			} else if (turnManager.playerTwoLastActions[i] == 3) {
				p2Actions [activeHistoryP2].transform.GetChild (0).GetComponent<Text>().text = "Block";
			} else if (turnManager.playerTwoLastActions[i] == 4) {
				p2Actions [activeHistoryP2].transform.GetChild (0).GetComponent<Text>().text = "Nothing";
			}
		}
	}

	public void OpenPlayerOptions() {
		p1Options.SetActive (true);
		p2Options.SetActive (true);
	}
	public void ClosePlayerOptions() {
		p1Options.SetActive (false);
		p2Options.SetActive (false);
	}
}
