using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public float speed;
    public bool isAlive;
    [HideInInspector]
    public Transform spawnPosition;

    private float jumpDuration;
    private float jumpHeight;
    private bool isGrounded;
    private bool isLeft;
    private Vector3 motion;
    private RaycastHit hit;

    private Rigidbody rb;
	
	void Start () {
        spawnPosition = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
        this.transform.position = spawnPosition.position;
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

            if (Input.GetKeyDown(KeyCode.D) && isLeft)
            {
                this.transform.rotation = Quaternion.Euler(Vector3.zero);
                isLeft = false;
            }
            else if (Input.GetKeyDown(KeyCode.A) && !isLeft)
            {
                this.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                isLeft = true;
            }

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
                jumpDuration += 0.0162f;
            }
            else if (jumpDuration >= 0.79f && isGrounded)
                jumpDuration = 0.0f;
        }
        else
        {
            spawnPosition = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
            this.transform.position = spawnPosition.position;
            isAlive = true;
        }
	}
}
