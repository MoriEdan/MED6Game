using UnityEngine;
using System.Collections;

public class RaycastInteract : MonoBehaviour {

	public RaycastHit hit;
	private GameObject lastLookedAt;
	Interact currInteractScript;
	Interact prevInteractScript;


	
	
	void Start () {
		
	}
	
	
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2));

		if (Physics.Raycast (ray, out hit, 3) && hit.collider.gameObject.GetComponent<Interact> () != null) {

			lastLookedAt = hit.collider.gameObject;
			lastLookedAt.GetComponent<Interact> ().OnLookEnter ();

			if (Input.GetKeyDown (KeyCode.E)) {
				hit.collider.gameObject.GetComponent<Interact> ().interact ();
			}
		} else {
			if (lastLookedAt != null) {
				lastLookedAt.GetComponent<Interact> ().OnLookExit ();
			}
		}
	}
}