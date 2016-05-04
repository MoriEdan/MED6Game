using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float fuel = 2.0f, maxFuel = 2.0f;
	CharacterController cc;
	public float speed;
	public bool isAlive;
	[HideInInspector]
	public Transform spawnPosition;

	private float jumpDuration;
	private float jumpHeight;
	private float x;
	private bool isGrounded;
	private bool isLeft;
	private bool canLeft;
	private bool keyboard = true;
	private Vector3 motion;
	private RaycastHit hit, frontHit;

	public AudioSource jump;
	public AudioSource idle;
	public ParticleSystem particle;

	private Rigidbody rb;

	Rect fuelRect;
	Texture2D fuelTexture;
	public bool isRunning;

	void Start () {
		spawnPosition = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
		this.transform.position = spawnPosition.position;
		this.transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
		//this.transform.rotation = Quaternion.Euler(Vector3.zero);
		rb = GetComponent<Rigidbody>();
		speed = 5.9f;
		jumpHeight = 6.7f;
		isAlive = true;

		fuelRect.y -= fuelRect.height;

		fuelRect = new Rect (Screen.width/10, Screen.height*9/10, Screen.width/3, Screen.height/50);
		fuelTexture = new Texture2D (1, 1);
		fuelTexture.SetPixel (0, 0, Color.green);
		fuelTexture.Apply ();
	}

	void SetRunning(bool isRunning){
		this.isRunning = isRunning;
	}

	void Update () {

		if (isAlive)
		{

			// Jump
			if (Physics.Raycast(this.transform.position, -this.transform.up, out hit, 1.3f))
			{
				if (!isGrounded && hit.collider.gameObject.tag != "Player")
					isGrounded = true;
			}
			else
				isGrounded = false;

			if (Physics.Raycast(this.transform.position, this.transform.right, out frontHit, 0.48f))
			{
				if (frontHit.collider.gameObject != null)
				{
					if (frontHit.collider.gameObject.GetComponent<BoxCollider>() != null && frontHit.collider.gameObject.GetComponent<BoxCollider>().isTrigger)
					{
						canLeft = true;
					}
					else
						canLeft = false;
				}
				//Debug.Log("WALL!");
			}
			else
			{
				canLeft = true;
			}

			if (Input.GetKey(KeyCode.W) && jumpDuration <= 0.7f || Input.GetButton("PS4_X") && jumpDuration <= 0.7f)
			{
				rb.velocity = this.transform.up * jumpHeight;
				jumpDuration += Time.deltaTime;
				fuel -= Time.deltaTime+0.04f;

				if(fuel < 0){
					fuel = 0;
				}


				//particle.startSize = 0.35f;
				if (isGrounded)
					jump.Play();
			}
			else if(fuel < maxFuel && isGrounded){
				fuel = maxFuel;

			}

			else if (jumpDuration >= 0.7f && isGrounded){
				jumpDuration = 0.0f;

			}


			else
				//particle.startSize = 0.13f;

				// Movement
				if (Input.GetKeyDown(KeyCode.F11))
					keyboard = !keyboard;

			if (keyboard)
			{
				if (Input.GetKey(KeyCode.A)){
					x = -1.0f;
					SetRunning (true);
				}

				else if (Input.GetKeyUp(KeyCode.A)){
					SetRunning (false);
				}

				else if (Input.GetKey(KeyCode.D)){
					x = 1.0f;
					SetRunning (true);
				}

				else if (Input.GetKeyUp(KeyCode.D)){
					SetRunning (false);
				}

				else
					x = 0.0f;
			}
			else
				x = Input.GetAxis("PS4_DPadHorizontal");

			if (!canLeft)
			{
				if (isLeft)
					x = Mathf.Clamp(x, 0f, 1f);
				else
					x = Mathf.Clamp(x, -1f, 0f);
			}
			motion = new Vector3(x, 0.0f, 0.0f);

			this.rb.MovePosition(this.transform.position + motion * speed * Time.deltaTime);

			// Rotation
			if (Input.GetKeyDown(KeyCode.D) && isLeft || Input.GetAxis("PS4_DPadHorizontal") < 0.0f && isLeft)
			{
				//this.transform.rotation = Quaternion.Euler(Vector3.zero);
				this.transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
				isLeft = false;
			}
			else if (Input.GetKeyDown(KeyCode.A) && !isLeft || Input.GetAxis("PS4_DPadHorizontal") > 0.0f && isLeft)
			{
				this.transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
				//this.transform.rotation = Quaternion.Euler(0.0f, 180f, 0.0f);
				isLeft = true;
			}
		}
		else
		{
            //spawnPosition = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
            //this.transform.position = spawnPosition.position;
            transform.position = GameObject.Find("SpawnPointAdjuster").GetComponent<SpawnPointAdjustmentScript>().SetSpawnPoint();
            isAlive = true;
		}
	}

	void OnGUI(){
		float fuelRatio = fuel / maxFuel;
		float fuelRectWidth = fuelRatio*Screen.width / 3;
		fuelRect.width = fuelRectWidth;
		GUI.DrawTexture (fuelRect, fuelTexture);

	}
}
