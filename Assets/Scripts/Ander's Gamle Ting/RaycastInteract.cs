using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RaycastInteract : MonoBehaviour {

	private float interactReach = 2.5f;

	public RaycastHit hit;
	private GameObject lastLookedAt;
	Interact currInteractScript;
	Interact prevInteractScript;

	private GameObject[] Buttons;
	
	void Start () {
		Buttons = GameObject.FindGameObjectsWithTag ("Button");
	}
	
	
	void Update () {
		//Ray ray = Camera.main.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2));

		for(int i = 0; i<Buttons.Length;i++){
			if(Vector3.Angle (Buttons [i].transform.position - transform.position, transform.forward)<30 && 
				Vector3.Magnitude(Buttons [i].transform.position-transform.position)<interactReach){

				lastLookedAt = Buttons [i];
				lastLookedAt.GetComponent<Interact> ().OnLookEnter ();

				if (Input.GetKeyDown (KeyCode.E)) {
					Buttons [i].GetComponent<Interact> ().interact ();
				}
				} else {
					if (lastLookedAt != null) {
						Buttons[i].GetComponent<Interact> ().OnLookExit ();
					}
				}
			}
		}
	}
