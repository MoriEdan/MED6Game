using UnityEngine;
using System.Collections;

public class CanonBombScrpt : MonoBehaviour {

    private Rigidbody rb;
    private bool shot;
    private float speed = 500f;

    private float count;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	
	void FixedUpdate () {
        if (count >= 2.21f)
        {
            count = 0.0f;
            Destroy(this.gameObject);
        }
        else
        {
            count += Time.deltaTime;
        }
	}
}
