using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {
	private GameController gameController;
	private bool picked;
	private AudioSource audioSource;
	public AudioClip pickupAudio;
	public Transform scoreText;
	private bool playedSound;
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		picked = false;
		playedSound = false;
		gameController = GameObject.Find("MoonTheGod").GetComponent<GameController>();
	}

	void Update () {
		if (gameController.inputEnabled) {
			transform.Rotate (1, 0, 0);
		}
		if (picked) {
			transform.position = Vector3.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(scoreText.position), 0.5f); 
		}
		if (transform.position == Camera.main.ScreenToWorldPoint(scoreText.position)) {
			if (!playedSound) {
				audioSource.PlayOneShot (pickupAudio);
				playedSound = true;
			}
			Destroy (gameObject, 0.3f);
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.name == "Avian") {
			picked = true;
		}
	}
}
