using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	public bool isActive;
	public GameObject[] objectsToActivate;
	private bool allowSendActivation = true;
	private bool hasPlayed = false;
	private Animation anima;
	private Interact interact;

	// Use this for initialization
	void Start () {
		interact = GetComponent <Interact>();
	}
	
	// Update is called once per frame
	void Update () {
		if (interact.activated && !isActive ) {
			InteractWithObjects ();
			isActive = true;

		}
		else if (!interact.activated && isActive)
		{
			InteractWithObjects ();
			isActive = false;

		}
	}

	void InteractWithObjects()
	{
		//        if (allowSendActivation)
		//        {
		for (int i = 0; i < objectsToActivate.Length; i++)
		{
			if (objectsToActivate[i].GetComponent<Interact>() == true)
				objectsToActivate[i].GetComponent<Interact>().interact();
		}
		//            allowSendActivation = false; // only activate once! (because the activated is a bool)
		//        }
	}
}
