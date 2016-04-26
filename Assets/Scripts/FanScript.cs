using UnityEngine;
using System.Collections;

public class FanScript : MonoBehaviour {

    [SerializeField]
    private Transform fan;

    private Vector3 direction;
    private float speed = 1.6f;


    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            direction = Vector3.Normalize(col.gameObject.transform.position - fan.position);
            direction.z = 0.0f;
            col.gameObject.transform.position += direction * speed * Time.deltaTime;
        }
    }
}
