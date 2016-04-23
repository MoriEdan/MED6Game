using UnityEngine;
using System.Collections;

public class TurretShotScript : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        //Kill player if hit
        // add here---
        Destroy(this.gameObject);
    }
}
