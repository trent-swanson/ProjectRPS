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
	float timer;
	int currentTime;

	void Start() {
		turnManager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<TurnManager> ();
		timer = 1;
		currentTime = Mathf.RoundToInt(turnManager.getCurrentTurnTime());
		OpenPlayerOptions ();
	}

	void Update() {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			timer = 1;
			currentTime--;
			timerObject.GetComponent<Image> ().sprite = timerSprites [currentTime];
		}
		if (currentTime <= 0) {
			currentTime = Mathf.RoundToInt(turnManager.getCurrentTurnTime() + 1);
		}
	}

	public void UpdateActionHistory() {
		ClosePlayerOptions ();
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

	public void OpenPlayerOptions() {
		p1Options.SetActive (true);
		p2Options.SetActive (true);
	}
	public void ClosePlayerOptions() {
		p1Options.SetActive (false);
		p2Options.SetActive (false);
	}
}
