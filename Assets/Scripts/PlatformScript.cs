using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Player")
            col.gameObject.transform.parent = this.transform;
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player")
            col.gameObject.transform.parent = null;
    }
}
