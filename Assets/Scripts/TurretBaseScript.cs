using UnityEngine;
using System.Collections;

public class TurretBaseScript : MonoBehaviour {

    public GameObject turretshot;
    public GameObject canonshot;

    public float timer = 0.89f;
    private float timeCount;
    private float shootForce = 500f;
    private bool canRotate = true;


    public void TurretAiming(bool isNormalTurret, Transform target, float precision, float rotationSpeed)
    {
        Vector3 direction = this.transform.position - target.position;

        float totalPrecision = precision;
        if (!isNormalTurret)
            totalPrecision = precision + 10.0f;

        if (Vector3.Angle(this.transform.right, direction) > totalPrecision && canRotate)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
        else
        {
            canRotate = false;
            if (timeCount >= timer)
            {
                Shoot(isNormalTurret);
                timeCount = 0.0f;
            }
            else
                timeCount += Time.deltaTime;
        }
    }

    private void Shoot(bool state)
    {
        GameObject store = null;
        if (state)
            store = turretshot;
        else
            store = canonshot;
        GameObject clone = null;
        clone = Instantiate(store, this.transform.position, this.transform.rotation) as GameObject;

        if (clone.GetComponent<Rigidbody>() != null && !state)
            clone.GetComponent<Rigidbody>().AddForce(-clone.transform.right * shootForce);
        else if (!state)
            Debug.Log("Instansiated object does not have a rigidbody.");
        else if (state)
        {
            clone.GetComponent<Rigidbody>().AddForce(-clone.transform.right * shootForce);
            Quaternion q = Quaternion.FromToRotation(-Vector3.right, transform.forward);
            clone.transform.rotation *= q;
        }

        canRotate = true;
    }
}
