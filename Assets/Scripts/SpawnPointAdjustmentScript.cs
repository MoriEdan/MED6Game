using UnityEngine;
using System.Collections;

public class SpawnPointAdjustmentScript : MonoBehaviour {

    public GameObject[] spawnVectors;

    private PlayerScript player;
    private bool errorHasOccured;

	void Awake () {
        if (spawnVectors.Length > 0)
        {
            for (int i = 0; i < spawnVectors.Length; i++)
            {
                if (spawnVectors[i].GetComponent<SpawnVectorScript>() == null)
                {
                    Debug.Log("SpawnVector GameObject No." + i + " does not have the required script Attached.");
                    errorHasOccured = true;
                    break;
                }
            }
            if (!errorHasOccured)
            {
                for (int i = 0; i < spawnVectors.Length - 1; i++)
                {
                    spawnVectors[i].GetComponent<SpawnVectorScript>().Direction(spawnVectors[i + 1].transform.position);
                }
            }
            else
                Debug.Log("Fix the error before continuing playing the game.");
        }
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
	}

	void FixedUpdate () {
        if (!player.isAlive)
        {
            for (int i = 0; i < spawnVectors.Length; i++)
            {
                if (spawnVectors[i].GetComponent<SpawnVectorScript>().hasPassed)
                    continue;
                else
                {
                    // New spawn point will be set.
                    break;
                }
            }
        }
	}
}
