﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Vector3 oldPos = new Vector3 (0,0,0);

	private float speedOriginal = 5f;
	private float speed = 5f;
	private float allowedFallSpeed = -0.04f;

	private Rigidbody rb;
	private MouseLook ml;
	private Vector3 moveVector;

	// ---- Start Menu Variables ----
	public float xStartRotation = 275.0f; // Change this Value in the inspector while testing.

	private float requiredTime = 2.0f;
	private float counter = 0.0f;
	private float threshold = 0.7f;
	public bool hasRisen = false; // CHANGE BEFORE EXPORTING FINAL GAME! this is only public because of easy testing other levels.
	private Vector3 startRot;

	// ------------------------------

	// Use this for initialization
	void Start () {

		this.gameObject.layer = 2;
		startRot = new Vector3(xStartRotation, 0.0f, 0.0f);
		transform.rotation = Quaternion.Euler(startRot);
		ml = GameObject.Find("PlayerCamera").GetComponent<MouseLook>();
		rb = GetComponent<Rigidbody>();
		speed = speedOriginal;
	
	}
	
	// Update is called once per frame
	void Update () {

		counter = Mathf.Clamp(counter, 0.0f, 2.0f);

		controlFall2 ();

		//Rotating with the camera
		rb.transform.rotation = Quaternion.Euler(0f, ml.CurrentYRotation, 0f);
		//Walking the direction, of the camera

		moveVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
		rb.transform.Translate(moveVector * speed * Time.deltaTime);
	
	}

	void controlFall2()
	{
		float yDif = transform.position.y - oldPos.y;
		//		yDifShow = yDif;

		if (yDif < allowedFallSpeed) {
			speed = speedOriginal * 0.5f;
		} 
		else {
			speed = speedOriginal;
		}

		oldPos = transform.position;
	}
}
