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
	public Sprite[] historySprites;
	int currentTime;
	int activeHistory;

	void Start() {
		turnManager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<TurnManager> ();
		currentTime = Mathf.RoundToInt(turnManager.getCurrentTurnTime());
		activeHistory = 0;
	}

	void Update() {
		currentTime = (int)turnManager.getCurrentTurnTime ();
		if (currentTime < 11) {
			timerObject.GetComponent<Image> ().sprite = timerSprites [currentTime];
		}
	}

	public void UpdateActionHistory() {
		ClosePlayerOptions ();

		if (activeHistory <= 4) {
			p1Actions [activeHistory].SetActive (true);
			p2Actions [activeHistory].SetActive (true);
			activeHistory++;
		}

		for (int i = 0; i < p1Actions.Length; i++) {
			//Debug.Log (turnManager.playerOneLastActions.Count - (i + 1));
			if (p1Actions [i].activeSelf == true) {
				p1Actions [i].GetComponent<Image> ().sprite = historySprites [turnManager.playerOneLastActions [turnManager.playerOneLastActions.Count - (i + 1)]];
			}

		}

		for (int i = 0; i < p2Actions.Length; i++) {
			if (p2Actions [i].activeSelf == true) {
				p2Actions [i].GetComponent<Image> ().sprite = historySprites [turnManager.playerTwoLastActions [turnManager.playerTwoLastActions.Count - (i + 1)]];
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
	public void ClosePlayerOptions(int playerOptions) {
		if (playerOptions == 1) {
			p1Options.SetActive (false);
		} else if (playerOptions == 2) {
			p2Options.SetActive (false);
		}
	}
}
