using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {

    public bool isTurret = true;

    private float rotationSpeed;
    private float precision;
    private float counter;
    private Vector3 direction;
    private Transform player;



    private TurretBaseScript TurretBase;



	void Start () {
        rotationSpeed = 1.5f;
        precision = 5.0f;
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;

        }
        TurretBase = GetComponent<TurretBaseScript>();
	}
	
	
	void FixedUpdate () {
        if (Vector3.Distance(this.transform.position, player.position) < 13.14f)
            TurretBase.TurretAiming(isTurret, player, precision, rotationSpeed);

	}

}
