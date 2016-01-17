using UnityEngine;
using System.Collections;


public class SideSpawner : MonoBehaviour
{
    public GameObject gObject, gObject2, gObject3, gObject4;
    [Range(0f, 3.0f)]
    public float SpawnTime;

    void Start()
    {
        InvokeRepeating("Spawn", 0.5f, SpawnTime);
    }

    void Spawn()
    {
        int rand = Random.Range(0, 4);

        if (rand == 0)
        {
            Instantiate(gObject, GameObject.Find("LeftSpawner").transform.position, Quaternion.identity);
        }
        else if (rand == 1)
        {
            Instantiate(gObject2, GameObject.Find("RightSpawner").transform.position, Quaternion.identity);
        }
        else if (rand == 2)
        {
            Instantiate(gObject3, GameObject.Find("RightSpawner").transform.position, Quaternion.identity);
        }
        else if (rand == 3)
        {
            Instantiate(gObject4, GameObject.Find("LeftSpawner").transform.position, Quaternion.identity);
        }



    }
}