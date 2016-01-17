using UnityEngine;
using System.Collections;
using System;

public class GarlicMoveLeft : MonoBehaviour
{

    public float fallSpeed = 3;
    public float leftSpeed = 3;
    public float distanceInBetween = 2;
    public float randNum = 0;
    public float lifeTime = 4;
    public int intervalInUnits = 10;
    public GameObject gObject;
    private float startingPosition;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.left * leftSpeed;
        startingPosition = gameObject.transform.position.x;
    }

    void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        if(startingPosition - intervalInUnits > gameObject.transform.position.x)
        {
            //Vector3 spawnPosition = new Vector3();
            Vector2 spawnPosition = this.gameObject.transform.position;
            spawnPosition.x = spawnPosition.x + distanceInBetween;
            Instantiate(gObject, spawnPosition, Quaternion.identity);
            spawnPosition.x = spawnPosition.x - distanceInBetween*2 ;
            Instantiate(gObject, spawnPosition, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player1")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
