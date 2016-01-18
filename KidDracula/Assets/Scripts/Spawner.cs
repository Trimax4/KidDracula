using UnityEngine;
using System.Collections;


public class Spawner : MonoBehaviour
{

    public GameObject gObject, gObject2, gObject3, gObject4;
    public float SpawnTime;
    private GameObject dataObject;
    private Timer localData;

    void Start()
    {
        dataObject = GameObject.Find("Timer");
        localData = dataObject.GetComponent<Timer>();
        InvokeRepeating("Spawn", 0.1f, SpawnTime);
    }

    void Spawn()
    {
        int pickSpawner = Random.Range(0, 3);
        string spawnerSelected = "Spawner (" + pickSpawner + ")";

        if (localData.checkPoint() == true)
        {
            SpawnTime -= .05f;
        }

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