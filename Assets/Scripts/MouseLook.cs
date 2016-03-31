using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	private float yRotation;
	private float xRotation;
	private float yRotationV;
	private float xRotationV;
	private float lookSmoothDamp = 0.1f;
	// Needed to move player currently
	private float currentYRotation;
	private float currentXRotation;

	private bool smoothActive = true;

	// Use this for initialization
	void Start () {

		currentXRotation = transform.rotation.x;
		currentYRotation = transform.rotation.y;
	
	}
	
	// Update is called once per frame
	void Update () {

		yRotation += Input.GetAxis("Mouse X");
		xRotation -= Input.GetAxis("Mouse Y");

		xRotation = Mathf.Clamp(xRotation, -90f, 90f);

		if (Input.GetKeyDown (KeyCode.P)) {
			smoothActive = !smoothActive;
		}

		if(smoothActive){
			currentXRotation = Mathf.SmoothDamp(currentXRotation, xRotation, ref xRotationV, lookSmoothDamp);
			currentYRotation = Mathf.SmoothDamp(currentYRotation, yRotation, ref yRotationV, lookSmoothDamp);
		} else {
			currentXRotation = xRotation;
			currentYRotation = yRotation;
		}




		this.transform.rotation = Quaternion.Euler(this.transform.rotation.x + currentXRotation, this.transform.rotation.y + currentYRotation, this.transform.rotation.z);
	
	}

	public float CurrentXRotation
	{
		get { return currentXRotation; }
	}

	public float CurrentYRotation
	{
		get { return currentYRotation; }
	}
}
