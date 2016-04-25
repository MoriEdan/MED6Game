using UnityEngine;
using System.Collections;

public class TurretShotScript : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
            col.gameObject.GetComponent<PlayerScript>().isAlive = false;
        Destroy(this.gameObject);
    }
}
