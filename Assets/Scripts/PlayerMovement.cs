using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	//ATTACHED TO THE PLAYER OBJECT

	private Vector3 oldPos = new Vector3 (0,0,0);

	private float speedOriginal = 5f;
	private float speed = 5f;
	private float allowedFallSpeed = -0.04f;

	private Rigidbody rb;
	private MouseLook ml;
	private Vector3 moveVector;
	public float xStartRotation = 275.0f;
	private Vector3 startRot;

	public bool Walking;


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

		controlFall2 ();

		//Rotating with the camera
		rb.transform.rotation = Quaternion.Euler(0f, ml.CurrentYRotation, 0f);

		//Walking the direction, of the camera
		moveVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
		rb.transform.Translate(moveVector * speed * Time.deltaTime);

		if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) {
			Walking = true;
		} else {
			Walking = false;
		}
	
	}

	void controlFall2()
	{
		float yDif = transform.position.y - oldPos.y;

		if (yDif < allowedFallSpeed) {
			speed = speedOriginal * 0.5f;
		} else {
			speed = speedOriginal;
		}
		oldPos = transform.position;
	}
}
