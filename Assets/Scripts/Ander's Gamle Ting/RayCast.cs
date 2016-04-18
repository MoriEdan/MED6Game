using UnityEngine;
using System.Collections;

// Lasted Edited: 29-10-2015 10:10

public class RayCast : MonoBehaviour {
    // Raycast script. Put this on the MainCamera object.

    private GameObject arms;
	public Transform rayCastObject;
    private float distance = 3f;
    RaycastHit objectHit;
    //private int count = 0;

    void Start()
    {
		
    }

    void Update()
    {

        // Physical representation of the Raycast for testing purposes
		Debug.DrawRay(rayCastObject.position, rayCastObject.forward * distance, Color.magenta);

        // For normal interactable objects

			if (Physics.Raycast(rayCastObject.position, rayCastObject.forward, out objectHit, distance) && objectHit.collider.gameObject.tag != "Player" && objectHit.collider.gameObject.tag != "Right Arm" && objectHit.collider.gameObject.tag != "Arm")
            {
                //Debug.Log(objectHit.collider.gameObject);
                //Debug.Log("Looking at object");
				if (Input.GetKeyDown(KeyCode.E))
                {
                    if (objectHit.collider.gameObject.tag == "Interactable")
                    {
                        // Proper action here. Activate object
                        // objectHit.collider.gameObject.GetComponent...
                    }
//                    else if (objectHit.collider.gameObject.tag == "Switch")
//                    {
//                        objectHit.collider.gameObject.GetComponent<SwitchScript>().isActive = !objectHit.collider.gameObject.GetComponent<SwitchScript>().isActive;
//                    }
                }
			}
        }
    }
