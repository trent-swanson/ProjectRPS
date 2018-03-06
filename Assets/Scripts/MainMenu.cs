using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject guidePanel;
	public GameObject creditsPanel;

	public void PlayGame() {
		SceneManager.LoadScene ("mainScene");
	}

	public void ExitGame() {
		Application.Quit ();
	}

	public void Guide() {
		if (guidePanel.activeSelf == false) {
			guidePanel.SetActive (true);
		} else {
			guidePanel.SetActive (false);
		}
	}

	public void Credits() {
		if (creditsPanel.activeSelf == false) {
			creditsPanel.SetActive (true);
		} else {
			creditsPanel.SetActive (false);
		}
	}
}
