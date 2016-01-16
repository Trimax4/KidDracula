using UnityEngine;
using System.Collections;
using System;

public class ObstacleRight : MonoBehaviour
{

    public float fallSpeed = 3;
    public float leftSpeed = 3;
    public float randNum = 0;
    public float lifeTime = 4;
    public int intervalInUnits = 10;
    public GameObject gObject;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.left * leftSpeed;
    }

    void Awake()
    {
        Destroy(gameObject, lifeTime);
    }
    void Update()
    {
        if(Math.Abs(gameObject.transform.position.x) == (Math.Abs(gameObject.transform.position.x) + intervalInUnits))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.down * fallSpeed;
        }
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
