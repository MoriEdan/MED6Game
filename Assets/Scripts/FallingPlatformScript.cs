using UnityEngine;
using System.Collections;

public class FallingPlatformScript : MonoBehaviour {

    private Rigidbody rb;

    private float count, delay;
    private bool entered;

	void Start () {
        rb = GetComponent<Rigidbody>();
        delay = 0.54f;
        if (rb.useGravity)
            rb.useGravity = false;
        if (!rb.isKinematic)
            rb.isKinematic = true;
	}

    void FixedUpdate()
    {
        if (entered)
        {
            if (count >= delay)
            {
                rb.useGravity = true;
                rb.isKinematic = false;
            }
            else
                count += Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.transform.parent = this.transform;
            entered = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.transform.parent = null;
            entered = false;
        }
    }
}
