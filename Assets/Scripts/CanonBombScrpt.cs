using UnityEngine;
using System.Collections;

public class CanonBombScrpt : MonoBehaviour {

    [SerializeField]
    public ParticleSystem particle;

    private float count;
    private bool death;

    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

	
	void FixedUpdate () {
        if (count >= 2.21f && !death)
        {
            
            // Emit particle system of explosion!
            particle.Play();
            death = true;
        }
        else if (death)
        {
            if (count >= 2.34f)
            {
                count = 0.0f;
                if (Vector3.Distance(this.gameObject.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 2.8f)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().isAlive = false;
                }
                Destroy(this.gameObject);
            }
            else
                count += Time.fixedDeltaTime;
        }
        else
        {
            count += Time.fixedDeltaTime;
        }
	}

}
