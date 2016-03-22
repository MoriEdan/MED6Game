using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {
	
	public bool interactableByPlayer = true;
	public bool activated;
    private Renderer rend;


    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.material.color = Color.white;
    }

	public void OnLookEnter(){
		// change color here?
	}

	public void interact()
	{
//		Debug.Log ("interacted");
        if (!activated)
        {
            rend.material.color = Color.green;
            activated = true;
        }
        else
        {
            rend.material.color = Color.white;
            activated = false;
        }
	}
	
}

