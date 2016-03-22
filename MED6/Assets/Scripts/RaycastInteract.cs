using UnityEngine;
using System.Collections;

public class RaycastInteract : MonoBehaviour {

	public RaycastHit hit;
	
	
	void Start () {
		
	}
	
	
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2));

		if(Physics.Raycast(ray,out hit, 3)){
			// change color here (OnLookEnter, in 'Interact' script?)
			if(Input.GetKeyDown(KeyCode.E)){
				hit.collider.gameObject.GetComponent<Interact> ().interact();
			}
		}
	}
}