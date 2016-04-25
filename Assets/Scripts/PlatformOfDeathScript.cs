using UnityEngine;
using System.Collections;

public class PlatformOfDeathScript : MonoBehaviour {


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
            col.gameObject.GetComponent<PlayerScript>().isAlive = false;
    }
}
