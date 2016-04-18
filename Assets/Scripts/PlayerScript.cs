using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public float speed;
    public bool isAlive;

    private float jumpDuration;
    private float jumpHeight;
    private Vector3 motion;

    private Rigidbody rb;
	
	void Start () {
        rb = GetComponent<Rigidbody>();
        speed = 5.4f;
        isAlive = true;
	}
	
	
	void Update () {
        if (isAlive)
        {
            motion = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            rb.transform.Translate(motion * speed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.velocity = transform.up * jumpHeight;
            }
        }
	}
}
