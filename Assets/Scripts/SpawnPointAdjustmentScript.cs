using UnityEngine;
using Affdex;
using System.Collections;

public class SpawnPointAdjustmentScript : MonoBehaviour {

    public GameObject[] spawnVectors;

    private PlayerScript player;
    private bool errorHasOccured;
    public int minBacktrack;
    private Vector3 spawn;

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
        spawn = spawnVectors[0].transform.position;
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

    public Vector3 SetSpawnPoint()
    {
        for (int i = 0; i < spawnVectors.Length; i++)
        {
            if (spawnVectors[i].GetComponent<SpawnVectorScript>().hasPassed)
                continue;
            else
            {
                // New spawn point will be set.
                int ran = (int)Random.Range(minBacktrack, i-1);
                if (ran == 0)
                    FindSpawn(spawnVectors[ran].transform.position, spawnVectors[ran + 1].transform.position);
                else
                    FindSpawn(spawnVectors[ran].transform.position, spawnVectors[0].transform.position);
                break;
            }
        }
        return spawn;
    }

    private void FindSpawn(Vector3 a, Vector3 b)
    {
        float _a = (a.y - b.y) / (a.x - b.x);
        float _b = a.y - _a * a.x;
        float x = Random.Range(a.x, b.x);
        float y = _a * x + _b;
        spawn = new Vector3(x, y, 0.0f);
        Debug.Log(spawn);
    }
}
