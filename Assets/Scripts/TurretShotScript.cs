using UnityEngine;
using System.Collections;

public class TurretShotScript : MonoBehaviour {

    public float speed = 3.67f;

	void FixedUpdate () {
        //this.transform.Translate(this.transform.position + -this.transform.right * speed * Time.deltaTime);
        //this.transform.position += -this.transform.forward * speed * Time.fixedDeltaTime;
	}
}
