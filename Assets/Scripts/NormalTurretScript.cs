using UnityEngine;
using System.Collections;

public class NormalTurretScript : MonoBehaviour {

    public float maxDistance;
    public float rotationSpeed;
    public float presision;
    public float delayTimer;

    private bool inTarget;
    private float counter;
    private Vector3 direction;
    private Transform player;

	void Start () {
        maxDistance = 14.0f;
        rotationSpeed = 1.2f;
        presision = 20.0f;
        delayTimer = 2.61f;
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
	}
	
	
	void FixedUpdate () {
        if (Vector3.Distance(this.transform.position, player.position) < maxDistance)
        {
            direction = transform.position - player.position;
            if (Vector3.Angle(this.transform.right, direction) > presision)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.fixedDeltaTime * rotationSpeed);
            }
            else
            {
                Shoot();
            }
        }
	}

    void Shoot()
    {
        
    }
}
