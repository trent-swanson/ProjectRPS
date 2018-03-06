using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour {

	public SpriteRenderer background;
	public Sprite player1, player2;
	public float endSceneTime = 15;
	float timer;

	void Start() {
		timer = endSceneTime;
		if (RPSLogic.winner == 1) {
			background.sprite = player1;
		} else {
			background.sprite = player2;
		}
	}

	void Update() {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			SceneManager.LoadScene("mainMenu");
		}
	}

	public void Menu() {
		SceneManager.LoadScene("mainMenu");
	}
}
