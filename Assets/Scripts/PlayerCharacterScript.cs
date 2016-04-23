using UnityEngine;
using System.Collections;

public class PlayerCharacterScript : MonoBehaviour {

    private bool isLeft;

	void Start () 
    {
	    
	}

	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.A) && !isLeft)
        {
            //this.transform.rotation = Quaternion.Euler(-90f, 0f, -90f);
            //this.transform.rotation = Quaternion.Euler(-this.transform.rotation.x, -this.transform.rotation.y, -this.transform.rotation.z);
            isLeft = true;
        }
        else if (Input.GetKeyDown(KeyCode.D) && isLeft)
        {
            //this.transform.rotation = Quaternion.Euler(-90f, 0f, 90f);
            //this.transform.rotation = Quaternion.Euler(-this.transform.rotation.x, -this.transform.rotation.y, -this.transform.rotation.z);
            isLeft = false;
        }
	}
}
