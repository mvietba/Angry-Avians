using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScene : MonoBehaviour {

	public void OnStart() {
		Debug.Log ("Load Game Scene");
		SceneManager.LoadScene("GameScene", LoadSceneMode.Single);

	}
	public void OnExit() {
		Application.Quit();
	}
}
