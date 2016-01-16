﻿using UnityEngine;
using System.Collections;

public class ObstacleScript : MonoBehaviour
{

    public float fallSpeed = 30;
    public float randNum = 0;
    public float lifeTime = 0;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * fallSpeed;
    }

    void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }

}