using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	private GameObject avian;
	public GameObject popup;
	public GameObject instructions;
	private PlayerController playerController;
	public Text forceText;
	public Text scoreText;
	public Text popupScoreText;
	private bool gameOver;
	public bool inputEnabled;
	// Use this for initialization
	void Start () {
		gameOver = false;
		avian = GameObject.Find("Avian");
		playerController = avian.GetComponent<PlayerController>();
		inputEnabled = false;
		Time.timeScale = 0;
	}
	
	void Update () {
		if (!gameOver) {
			if (playerController.delay > 100 && 
				playerController.launched && 
				avian.GetComponent<Rigidbody2D>().velocity.sqrMagnitude <= 0.0) {
				OnGameOver ();
			}
			if (playerController.pressed) {
				forceText.text = playerController.newForce.ToString ();
			}
			if (playerController.launched) {
				scoreText.text = playerController.score.ToString ();
			}
		}
	}

	private void OnGameOver() {
		popup.SetActive(true);
		Time.timeScale = 0;
		inputEnabled = false;
		gameOver = true;
		popupScoreText.text = "Your score: " + playerController.score.ToString();
	}
	public void OnStart() {
		inputEnabled = true;

		Time.timeScale = 1;
		instructions.SetActive (false);

	}
	public void OnRestart() {
		inputEnabled = true;

		Time.timeScale = 1;
		Debug.Log ("Restart Scene");
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void OnExit() {
		Debug.Log ("Quit");
		Application.Quit();
	}
}
