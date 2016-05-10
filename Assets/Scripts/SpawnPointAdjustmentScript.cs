using UnityEngine;
using Affdex;
using System.Collections;

public class SpawnPointAdjustmentScript : MonoBehaviour {

    public SpawnVectorScript[] spawnVectors;
    
    private PlayerScript player;
    private bool errorHasOccured;
    private Vector3 spawn;
    private int lastSpawn = 0;
    private int meanDiv;
    private int checkRate;
    private float adjustedPosition;
    private float meanAnger;

    private PlayerEmotions playerEmo;

    public int minBacktrack;

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
                    spawnVectors[i].Direction(spawnVectors[i + 1].transform.position);
                }
            }
            else
                Debug.Log("Fix the error before continuing playing the game.");
        }
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        playerEmo = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerEmotions>();
        spawn = spawnVectors[0].transform.position;
	}

    void FixedUpdate()
    {
        if (player.isAlive)
        {
            meanDiv++;
            meanAnger += playerEmo.currentAnger;
        }
    }

    public Vector3 SetSpawnPoint()
    {
        for (int i = lastSpawn; i < spawnVectors.Length; i++)
        {
            if (spawnVectors[i].hasPassed)
                continue;
            else
            {

                float theMean = meanAnger / meanDiv;

                adjustedPosition = (i - 1) * (theMean / 100f);
                if ((int)adjustedPosition <= lastSpawn)
                    adjustedPosition = lastSpawn;

                if ((int)adjustedPosition < lastSpawn + 2)
                {
                    FindSpawn(spawnVectors[(int)adjustedPosition].transform.position, spawnVectors[(int)adjustedPosition + 1].transform.position);
                    lastSpawn = (int)adjustedPosition;
                }
                else
                {
                    FindSpawn(spawnVectors[(int)adjustedPosition - 1].transform.position, spawnVectors[(int)adjustedPosition].transform.position);
                    lastSpawn = (int)adjustedPosition - 1;
                }
                break;
            }
        }
        meanDiv = 0;
        meanAnger = 0.0f;
        return spawn;
    }

    private void FindSpawn(Vector3 a, Vector3 b)
    {
        //float _a = (a.y - b.y) / (a.x - b.x);
        //float _b = a.y - _a * a.x;
        float x = Random.Range(a.x, b.x);
        float y = 0.0f;
        if (a.y > b.y)
            y = a.y;
        else
            y = b.y;
        spawn = new Vector3(x, y, 0.0f);
        Debug.Log(spawn);
    }
}
