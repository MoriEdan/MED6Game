using UnityEngine;
using System.Collections;

public class Pathfinding : MonoBehaviour {

    private NavMeshAgent agent;
    private GameObject goTo;

	void Start () {
        agent = GetComponent<NavMeshAgent>();
        goTo = GameObject.Find("GoTo");
	}
	
	
	void Update () {
        agent.SetDestination(goTo.transform.position);
	}
}
