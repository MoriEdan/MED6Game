﻿using UnityEngine;
using System.Collections;

public class TurretShotScript : MonoBehaviour {

    public float speed;

	void FixedUpdate () {
        this.transform.Translate(this.transform.position + -this.transform.right * speed * Time.deltaTime);
	}
}
