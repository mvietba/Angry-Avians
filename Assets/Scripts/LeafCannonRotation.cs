using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafCannonRotation : MonoBehaviour {
	private float speed;
	private GameController gameController;
	//public Rigidbody2D leafCannon;
	public Transform target;
	private Vector3 axis = new Vector3(0, 0, 1);
	// Use this for initialization
	void Start () {
		speed = 1;
		gameController = GameObject.Find("MoonTheGod").GetComponent<GameController>();
	}

	// Update is called once per frame
	void Update () {
		if (gameController.inputEnabled) {
			if (Input.GetKey ("up"))
				transform.RotateAround (target.position, axis, speed * 1);

			if (Input.GetKey ("down"))
				transform.RotateAround (target.position, axis, speed * -1);
		}
	}
}
