using UnityEngine;
using System.Collections;

public class Pathfinding : MonoBehaviour {

    private NavMeshAgent agent;
    private GameObject player;
    private GameObject[] endPoints;
    private Transform shortestDist;
    private bool goTo;
    private float count;

	void Start () {
        agent = GetComponent<NavMeshAgent>();
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
	}
	
	
	void Update () {
        // Checks distance every set seconds
        if (count >= 1.29f)
        {
            if (Vector3.Distance(this.transform.position, player.transform.position) >= 3f)
            {
                goTo = true;
            }
            count = 0.0f;
        }
        else
        {
            count += Time.deltaTime;
        }
        // If object is too far away, move to the closest point
        if (goTo && player != null)
        {
            float dist = 1000.0f;
            endPoints = GameObject.FindGameObjectsWithTag("EndPoints");
            for (int i = 0; i < endPoints.Length; i++)
            {
                float stored = Vector3.Distance(endPoints[i].transform.position, this.transform.position);
                if (stored < dist)
                {
                    dist = stored;
                    shortestDist = endPoints[i].transform;
                }
            }
            agent.SetDestination(shortestDist.position);
            goTo = false;
        }
	}
}
