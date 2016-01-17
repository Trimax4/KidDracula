using UnityEngine;
using System.Collections;
using System;

public class ObstacleLeft : MonoBehaviour
{
    public float fallSpeed = 3;
    public float rightSpeed = 3;
    public float randNum = 0;
    public float lifeTime = 4;
    public int intervalInUnits = 3;
    private float startingPosition;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * rightSpeed;
        startingPosition = gameObject.transform.position.x;
    }

    void Awake()
    {
        Destroy(gameObject, lifeTime);
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
