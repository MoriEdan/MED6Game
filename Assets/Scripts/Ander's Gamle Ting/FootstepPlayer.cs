using UnityEngine;
using System.Collections;

public class FootstepPlayer : MonoBehaviour {
	private RaycastHit hit = new RaycastHit();
	private bool walkCheck;
	private bool isRPlaying, isAnythingPlaying;

	private GameObject[] RData;
	private int d8, d8old;

void Start () {

	RData = new GameObject[8];

	//Rock
	RData[0] = GameObject.Find ("R1");
	RData[1] = GameObject.Find ("R2");
	RData[2] = GameObject.Find ("R3");
	RData[3] = GameObject.Find ("R4");
	RData[4] = GameObject.Find ("R5");
	RData[5] = GameObject.Find ("R6");
	RData[6] = GameObject.Find ("R7");
	RData[7] = GameObject.Find ("R8");

}


void Update () {
		walkCheck = GameObject.Find ("Player").GetComponent<PlayerMovement> ().Walking;

		//Checks if player is walking
		if (walkCheck) {
			
			d8old = d8;
			while (d8 == d8old) {
				d8 = Random.Range (0, 7);
			}

			isRPlaying = false;

			//Checks if there is a surface beneath the player
			if (walkCheck && Physics.Raycast (transform.position, -Vector3.up, out hit, 3)) {

				if (isAnythingPlaying == false) {
					//Stops all sounds, plays a footstep, then starts playing a new footstep every .5 sec
					switch (hit.collider.gameObject.tag) {
					case "Stone Floor":
						isRPlaying = true;
						ShutUp ();
						RData [d8].GetComponent<AudioSource> ().Play ();
						RData [d8].GetComponent<AudioSource> ().volume = 1;
						StartCoroutine (RPlayer ());
						break;
					default:
						break;
					}
					isAnythingPlaying = true;
				}
			}
		}
	}


//Plays a footstep after a .5 sec wait
private IEnumerator RPlayer(){
	yield return new WaitForSeconds (0.5f);
	if (isRPlaying) {
		RData[d8].GetComponent<AudioSource>().Play ();
	}
	isRPlaying = false;
	isAnythingPlaying = false;
}

//Stops all sounds
void ShutUp(){
	for(int i=0; i<RData.Length; i++){
		RData[i].GetComponent<AudioSource>().volume-=0.4f;
	}
}

}