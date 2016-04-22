using UnityEngine;
using System.Collections;

public class MovingPlatformScript : MonoBehaviour {
    
    [SerializeField]
    private Transform startPoint = null, endPoint = null, platform = null;

    private Transform destination;
    private Vector3 direction;
    private float speed;

	void Awake () {
        if (platform.GetComponent<Rigidbody>() == null)
            Debug.Log("Platform is missing a Rigidbody");
        speed = 2.2f;
        platform.position = startPoint.position;
        SetDestination(endPoint);
	}

	void FixedUpdate () {
        platform.GetComponent<Rigidbody>().MovePosition(platform.position + direction * speed * Time.fixedDeltaTime);

        if (Vector3.Distance(platform.position, destination.position) < speed * Time.fixedDeltaTime)
            SetDestination(destination == startPoint ? endPoint : startPoint);
	}

    void SetDestination(Transform dest)
    {
        destination = dest;
        direction = Vector3.Normalize(destination.position - platform.position);
    }
}
