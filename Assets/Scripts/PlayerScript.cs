using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public float speed;
    public bool isAlive;

    private float jumpDuration;
    private float jumpHeight;
    private bool isGrounded;
    private Vector3 motion;
    private RaycastHit hit;

    private Rigidbody rb;
	
	void Start () {
        rb = GetComponent<Rigidbody>();
        speed = 5.9f;
        jumpHeight = 6.7f;
        isAlive = true;
	}
	
	
	void Update () {
        if (isAlive)
        {
            // Movement
            motion = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            this.rb.MovePosition(this.transform.position + motion * speed * Time.deltaTime);

            // Jump
            if (Physics.Raycast(this.transform.position, -this.transform.up, out hit, 1.3f))
            {
                if (!isGrounded)
                    isGrounded = true;
            }
            else
                isGrounded = false;

            if (Input.GetKey(KeyCode.W) && jumpDuration <= 0.79f)
            {
                rb.velocity = this.transform.up * jumpHeight;
                jumpDuration += Time.deltaTime;
            }
            else if (jumpDuration > 0.82f && isGrounded)
                jumpDuration = 0.0f;
        }
	}
}
