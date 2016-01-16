using UnityEngine;
using System.Collections;


public class Spawner : MonoBehaviour
{
    float buffer = 10.0f;
    public GameObject gObject;
    [Range(0f, 3.0f)]
    public float SpawnTime;

    void Start()
    {
        InvokeRepeating("Spawn", 0.5f, SpawnTime);
    }

    void Spawn()
    {
        float rand = Random.Range(0, 3);
        string spawnerSelected = "Spawner (" + rand + ")";
        Debug.Log(spawnerSelected);

        Instantiate(gObject, GameObject.Find(spawnerSelected).transform.position, Quaternion.identity);
    }
}