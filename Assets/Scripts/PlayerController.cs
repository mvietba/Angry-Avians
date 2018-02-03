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
	// Use this for initialization
	void Start () {
		launch = false;
		launched = false;
		pressed = false;
		baseForce = 100;
		delay = 0; //Needed to check pressed after a while to not end game when Avian just launched (velocity 0)
		avian = GetComponent<Rigidbody2D>();
		gameController = GameObject.Find("MoonTheGod").GetComponent<GameController>();
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
				Debug.Log ("Start!");
				pressed = true;
			}

			if (pressed) {
				newForce = Mathf.RoundToInt (baseForce * (Time.time - start)); 
			}

			//Finish starting time when spacebar is released
			if (Input.GetKeyUp (KeyCode.Space)) {
				//Calculate duration
				newForce = baseForce * (Time.time - start); 
				Debug.Log (newForce);
				Debug.Log ("Launch!");
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
	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.name.Contains("Coin")) {
			Destroy (col.gameObject);
			score += 10;
		}

		if (col.gameObject.name.Contains("crate")) {
			score += 5;
		}
	}
}
