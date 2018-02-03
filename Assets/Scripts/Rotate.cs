using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
	private GameController gameController;

	void Start () {
		gameController = GameObject.Find("MoonTheGod").GetComponent<GameController>();
	}

	void Update () {
		if (gameController.inputEnabled) {
			transform.Rotate (1, 0, 0);
		}
	}
}
