using UnityEngine;
using System.Collections;

public class SpawnVectorScript : MonoBehaviour {

	public bool hasPassed;

    private GameObject playerObj;
    private float direction = 1.0f;

	void Start () {
        playerObj = GameObject.FindGameObjectWithTag("Player");
	}
	
	void FixedUpdate () {
        if (!hasPassed)
        {
            if (direction > 0.1f)
            {
                if (playerObj.transform.position.x >= this.transform.position.x && Vector3.Distance(this.transform.position, playerObj.transform.position) <= 10.0f)
                    hasPassed = true;
            }
            else if (direction < -0.1f)
            {
                if (playerObj.transform.position.x >= this.transform.position.x && Vector3.Distance(this.transform.position, playerObj.transform.position) <= 10.0f)
                    hasPassed = true;
            }
        }
	}

    public float Direction(Vector3 a)
    {
        direction = Vector3.Normalize(this.transform.position - a).x;
        //Debug.Log(direction);
        return direction;
    }
}
