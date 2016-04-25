using UnityEngine;
using System.Collections;

public class CanonBombScrpt : MonoBehaviour {

    private Rigidbody rb;

    private float count;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	
	void FixedUpdate () {
        if (count >= 2.21f)
        {
            count = 0.0f;
            // Emit particle system of explosion!
            if (Vector3.Distance(this.gameObject.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 2.5f)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().isAlive = false;
            }
            Destroy(this.gameObject);
        }
        else
        {
            count += Time.deltaTime;
        }
	}

}
