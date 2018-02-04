using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	private GameObject avian;
	public GameObject popup;
	private PlayerController playerController;
	public GameObject cancelBtn;
	public Text forceText;
	public Text scoreText;
	public Text popupScoreText;
	private bool gameOver;
	public bool inputEnabled;
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		gameOver = false;
		avian = GameObject.Find("Avian");
		playerController = avian.GetComponent<PlayerController>();
		inputEnabled = true;
	}
	
	void Update () {
		if (!gameOver) {
			if (Input.GetKey (KeyCode.Escape)) {
				OnGameOver (true);
			}

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

	private void OnGameOver(bool isUserCalled = false) {
		popup.SetActive(true);
		Time.timeScale = 0;
		inputEnabled = false;
		popupScoreText.text = "Your score: " + playerController.score.ToString();
		if (isUserCalled)
			cancelBtn.SetActive(true);
		else {
			cancelBtn.SetActive(false);
			gameOver = true;
		}
	}

	public void OnRestart() {
		inputEnabled = true;

		Time.timeScale = 1;
		Debug.Log ("Restart Scene");
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void OnExit() {
		Application.Quit();
	}

	public void OnCancel() {
		popup.SetActive (false);
		inputEnabled = true;
		Time.timeScale = 1;
	}
}
