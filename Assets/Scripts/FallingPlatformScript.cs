using UnityEngine;
using System.Collections;

public class FallingPlatformScript : MonoBehaviour {

    private Rigidbody rb;

    private float count, delay;
    private bool entered;
    private RaycastHit hit;

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

        if (Physics.Raycast(this.transform.position, -this.transform.forward, out hit, 1.5f))
        {
            if(hit.collider.gameObject.tag != "Player")
                Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            entered = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            entered = false;
        }
    }
}
