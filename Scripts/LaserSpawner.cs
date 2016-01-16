using UnityEngine;
using System.Collections;


public class LaserSpawner : MonoBehaviour
{
    float buffer = 10.0f;
    public GameObject laser;
    [Range(0f, 3.0f)]
    public float SpawnTime;

    void Start()
    {
        InvokeRepeating("Spawn", 0.5f, SpawnTime);
    }

    void Spawn()
    {
        float rand = Random.Range(0, 23);
        string spawnerSelected = "Spawner (" + rand + ")"; 

        Instantiate(laser, GameObject.Find(spawnerSelected).transform.position, Quaternion.identity);
    }
}