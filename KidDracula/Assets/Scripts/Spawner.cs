using UnityEngine;
using System.Collections;


public class Spawner : MonoBehaviour
{
    float buffer = 10.0f;
    public GameObject gObject, gObject2, gObject3, gObject4;
    [Range(0f, 3.0f)]
    public float SpawnTime;

    void Start()
    {
        InvokeRepeating("Spawn", 0.5f, SpawnTime);
    }

    void Spawn()
    {
        int pickSpawner = Random.Range(0, 3);
        string spawnerSelected = "Spawner (" + pickSpawner + ")";

        int rand = Random.Range(0, 4);
//		Debug.Log (rand.ToString ());
		if (rand == 0) {
			Instantiate (gObject, GameObject.Find (spawnerSelected).transform.position, Quaternion.identity);
		} else if (rand == 1) {
			Instantiate (gObject2, GameObject.Find (spawnerSelected).transform.position, Quaternion.identity);
		} else if (rand == 2){
			Instantiate (gObject3, GameObject.Find (spawnerSelected).transform.position, Quaternion.identity);
		} else if (rand == 3){
			Instantiate (gObject4, GameObject.Find (spawnerSelected).transform.position, Quaternion.identity);
		}

        
    }
}