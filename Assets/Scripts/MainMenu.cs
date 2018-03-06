using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame() {
		SceneManager.LoadScene ("mainScene");
	}

	public void ExitGame() {
		Application.Quit ();
	}

	public void Guide() {
		
	}

	public void Credits() {
		
	}
}
