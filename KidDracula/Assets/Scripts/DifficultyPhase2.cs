using UnityEngine;
using System.Collections;


public class DifficultyPhase2 : MonoBehaviour
{

    public GameObject gObject;
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
        if (localData.getTime() > 1)
        {
            int pickSpawner = Random.Range(6, 9);
            string spawnerSelected = "Spawner (" + pickSpawner + ")";
            Debug.Log("d spawner");
            SpawnTime -= .2f;

            Instantiate(gObject, GameObject.Find(spawnerSelected).transform.position, Quaternion.identity);
        }
    }
}
