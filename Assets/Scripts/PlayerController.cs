using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	private float start;
	private bool launch;
	public bool launched;
	public bool pressed;
	private float baseForce;
	public float newForce;
	public Rigidbody2D avian;
	public int delay;
	public int score;
	private GameController gameController;
	public Image forceBar;
	public AudioClip explosionAudio;
	public AudioClip jumpAudio;
	private AudioSource audioSource;
	private float maxForce;
	// Use this for initialization
	void Start () {
		launch = false;
		launched = false;
		pressed = false;
		baseForce = 150;
		maxForce = 250f;
		newForce = 0f;
		delay = 0; //Needed to check pressed after a while to not end game when Avian just launched (velocity 0)
		avian = GetComponent<Rigidbody2D>();
		gameController = GameObject.Find("MoonTheGod").GetComponent<GameController>();
		audioSource = GetComponent<AudioSource> ();
		//forceText = GameObject.Find ("ForceValue").GetComponent<GUIText> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameController.inputEnabled) {
			if (launched) {
				newForce = newForce * 0.9f;
				delay += 1;
			}

			//Start counting time since spacebar was pressed
			if (Input.GetKeyDown (KeyCode.Space)) {
				start = Time.time;
				pressed = true;
			}

			if (pressed & newForce < maxForce) {
				newForce = Mathf.Min(Mathf.RoundToInt (baseForce * (Time.time - start)), maxForce);
				forceBar.fillAmount = Mathf.Min(newForce / maxForce, 1);
			}

			//Finish starting time when spacebar is released
			if (Input.GetKeyUp (KeyCode.Space)) {
				//Calculate duration
				newForce = baseForce * (Time.time - start); 
				launch = true;
				pressed = false;
			}

			if (launch) {
				avian.bodyType = RigidbodyType2D.Dynamic;
				avian.AddForce (transform.right * newForce);
				launched = true;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.name.Contains("Coin")) {
			Destroy(col.gameObject.GetComponent<CapsuleCollider2D>());
			score += 10;
		}
	}
	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.name.Contains ("wood-log")) {
			CollisionWithWoodenObjects (col.gameObject);
			score += 5;
		} else if (col.gameObject.name.Contains ("crate")) {
			CollisionWithWoodenObjects (col.gameObject);
			score += 2;
		} else
			audioSource.PlayOneShot (jumpAudio);
	}
		
	void CollisionWithWoodenObjects (GameObject obj) {
		audioSource.PlayOneShot (explosionAudio);
		obj.transform.Find ("Particle System").gameObject.SetActive (true);
		obj.GetComponent<BoxCollider2D>().isTrigger = true; // Prevent further collision detection with this item
		obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static; // Prevent from falling off the screen with isTrigger on
		Destroy (obj, 0.5f); //Delay to show explosion
	}
}
