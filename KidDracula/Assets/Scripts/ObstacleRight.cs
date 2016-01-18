using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class ObstacleRight : MonoBehaviour
{

    public float fallSpeed = 3;
    public float leftSpeed = 3;
    public float randNum = 0;
    public float lifeTime = 4;
    public int intervalInUnits = 100;
    private float startingPosition;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.left * leftSpeed;
        startingPosition = gameObject.transform.position.x;
    }

    void Update()
    {
        Vector3 rotation = transform.rotation.eulerAngles;
        rotation.z += 20;
        transform.rotation = Quaternion.Euler(rotation);
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
			SceneManager.LoadScene ("GameOverScreen");
        }
    }

    

}
