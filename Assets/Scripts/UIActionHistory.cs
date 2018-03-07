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
	public GameObject infoPanel;
	public GameObject timerObject;
	public Sprite[] timerSprites;
	public Sprite[] historySprites;
	int currentTime;
	int activeHistory;

	public AudioClip tickTock, longDong;
	public AudioSource timerAudio;
	bool dongPlayed = true;

	void Start() {
		turnManager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<TurnManager> ();
		currentTime = Mathf.RoundToInt(turnManager.getCurrentTurnTime());
		activeHistory = 0;
	}

	void Update() {
		currentTime = (int)turnManager.getCurrentTurnTime ();
		if (currentTime < 11) {
			if (!dongPlayed && currentTime == 0) {
				dongPlayed = true;
				timerAudio.loop = false;
				timerAudio.volume = 0.75f;
				timerAudio.clip = longDong;
				timerAudio.Play ();
			} else if (currentTime == 1) {
				dongPlayed = false;
			} else if (!timerAudio.isPlaying && currentTime != 0) {
				timerAudio.loop = true;
				timerAudio.volume = 0.35f;
				timerAudio.clip = tickTock;
				timerAudio.Play ();
			}
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
		infoPanel.SetActive (true);
		if (turnManager.playerOneLastActions.Count > 0) {
			LastActionChosen ();
		}
	}
	public void ClosePlayerOptions() {
		p1Options.SetActive (false);
		p2Options.SetActive (false);
		infoPanel.SetActive (false);
	}
	public void ClosePlayerOptions(int playerOptions) {
		if (playerOptions == 1) {
			p1Options.SetActive (false);
		} else if (playerOptions == 2) {
			p2Options.SetActive (false);
		}
	}

	void LastActionChosen() {
		for (int i = 0; i < p1Options.transform.childCount; i++) {
			Image tempImage = p1Options.transform.GetChild (i).GetComponent<Image> ();
			Color c = tempImage.color;
			c.a = 1f;
			tempImage.color = c;
		}
		for (int i = 0; i < p2Options.transform.childCount; i++) {
			Image tempImage = p2Options.transform.GetChild (i).GetComponent<Image> ();
			Color c = tempImage.color;
			c.a = 1f;
			tempImage.color = c;
		}

		//player 1
		if (turnManager.playerOneLastActions[turnManager.playerOneLastActions.Count - 1] == 0) {
			Image tempImage = p1Options.transform.GetChild (0).GetComponent<Image> ();
			Color c = tempImage.color;
			c.a = 0.5f;
			tempImage.color = c;
		}
		if (turnManager.playerOneLastActions[turnManager.playerOneLastActions.Count - 1] == 1) {
			Image tempImage = p1Options.transform.GetChild (2).GetComponent<Image> ();
			Color c = tempImage.color;
			c.a = 0.5f;
			tempImage.color = c;
		}
		if (turnManager.playerOneLastActions[turnManager.playerOneLastActions.Count - 1] == 2) {
			Image tempImage = p1Options.transform.GetChild (3).GetComponent<Image> ();
			Color c = tempImage.color;
			c.a = 0.5f;
			tempImage.color = c;
		}
		if (turnManager.playerOneLastActions[turnManager.playerOneLastActions.Count - 1] == 3) {
			Image tempImage = p1Options.transform.GetChild (1).GetComponent<Image> ();
			Color c = tempImage.color;
			c.a = 0.5f;
			tempImage.color = c;
		}

		//player 2
		if (turnManager.playerTwoLastActions[turnManager.playerTwoLastActions.Count - 1] == 0) {
			Image tempImage = p2Options.transform.GetChild (0).GetComponent<Image> ();
			Color c = tempImage.color;
			c.a = 0.5f;
			tempImage.color = c;
		}
		if (turnManager.playerTwoLastActions[turnManager.playerTwoLastActions.Count - 1] == 1) {
			Image tempImage = p2Options.transform.GetChild (2).GetComponent<Image> ();
			Color c = tempImage.color;
			c.a = 0.5f;
			tempImage.color = c;
		}
		if (turnManager.playerTwoLastActions[turnManager.playerTwoLastActions.Count - 1] == 2) {
			Image tempImage = p2Options.transform.GetChild (3).GetComponent<Image> ();
			Color c = tempImage.color;
			c.a = 0.5f;
			tempImage.color = c;
		}
		if (turnManager.playerTwoLastActions[turnManager.playerTwoLastActions.Count - 1] == 3) {
			Image tempImage = p2Options.transform.GetChild (1).GetComponent<Image> ();
			Color c = tempImage.color;
			c.a = 0.5f;
			tempImage.color = c;
		}
	}
}
