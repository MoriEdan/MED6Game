using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {
	
	public bool interactableByPlayer = true;
	public bool activated;
    public Renderer rend;
	public GameObject linkedDoor;



    void Start()
    {
        rend = GetComponent<Renderer>();
		rend.material.color = Color.grey;
    }



	public void OnLookEnter(){
		rend.material.color = Color.green;
	}

	public void OnLookExit(){
		rend.material.color = Color.grey;
	}

	public void interact()
	{
//		Debug.Log ("interacted");
        if (!activated)
        {
            activated = true;
			OpenDoor ();
        }
        else
        {
            //rend.material.color = Color.white;
            activated = false;
			CloseDoor ();
        }
	}

	public void OpenDoor(){
		linkedDoor.transform.position += new Vector3 (0, 5, 0);
	}
	public void CloseDoor(){
		linkedDoor.transform.position -= new Vector3 (0, 5, 0);
	}
	
}

