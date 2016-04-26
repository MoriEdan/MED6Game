using UnityEngine;
using System.Collections;

public class FanRotationScript : MonoBehaviour {

    private Vector3 rotation = new Vector3(0.0f, 0.0f, 1.0f);
    private float speed = 9.4f;
	
	void FixedUpdate () {
        this.transform.Rotate(rotation *  speed);
	}
}
