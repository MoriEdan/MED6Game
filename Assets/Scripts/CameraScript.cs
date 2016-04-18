using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    private GameObject player;

	void Start () {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            Debug.Log("Error: Cannot find a Gameobject with the tag: Player");
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
	}

	void Update () {
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10.0f);
	}
}
