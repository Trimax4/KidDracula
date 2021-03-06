﻿using UnityEngine;
using System.Collections;

public class PeopleScript : MonoBehaviour
{
    private GameObject dataObject;
	private Player_movement playerObject;
    private HealthBarController localData;
    private BloodCounter score;

	private static System.Collections.Generic.Dictionary<string, float> peopleToBlood
	= new System.Collections.Generic.Dictionary<string, float> ()
	{
		{"man", 5.5f},
		{"woman", 4.9f},
		{"child", 2.5f}
	};
        
    public float fallSpeed = 3;
    public float lifeTime = 0;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.down* fallSpeed;
        dataObject = GameObject.Find("VisualizedHealthBar");
        localData = dataObject.GetComponent<HealthBarController>();

		playerObject = GameObject.FindGameObjectWithTag ("Player1").GetComponent<Player_movement> ();

		dataObject = GameObject.FindGameObjectWithTag ("ScoreText");
		score = dataObject.GetComponent<BloodCounter>();
    }

    void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (gameObject.tag == "man")
        {
            Debug.Log("in man");
            GameObject.Find("Main Camera").GetComponent<SoundManager>().PlaySound(2);
        }
        if (gameObject.tag == "child")
        {
            GameObject.Find("Main Camera").GetComponent<SoundManager>().PlaySound(2);
        }
        if (gameObject.tag == "woman")
        {
            GameObject.Find("Main Camera").GetComponent<SoundManager>().PlaySound(1);
        }
        if (col.gameObject.tag == "Player1")
        {
            GameObject.Find("Main Camera").GetComponent<SoundManager>().PlaySound(4);
            //			Debug.Log (gameObject.tag + " eaten");
            float bloodWorth = peopleToBlood [gameObject.tag] * 10;
			localData.GainBloodBy(bloodWorth);
			score.AddBlood (bloodWorth);

			// animate the player
			if (gameObject.transform.position.x < col.gameObject.transform.position.x) {
				playerObject.Bite ("Left");
			} else {
				playerObject.Bite ("Right");
			}

            Destroy(gameObject);
        }
    }
}
