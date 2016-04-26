using UnityEngine;
using System.Collections;

public class TurretShotScript : MonoBehaviour {

    public float timer = 0.0f;


    void FixedUpdate()
    {
        if (timer >= 15.5f)
            Destroy(this.gameObject);
        else
            timer += Time.deltaTime;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" && col.gameObject.GetComponent<CapsuleCollider>())
            col.gameObject.GetComponent<PlayerScript>().isAlive = false;
        
        Destroy(this.gameObject);
    }
}
