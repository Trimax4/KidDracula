using UnityEngine;
using System.Collections;

public class PeopleScript : MonoBehaviour
{
    private GameObject dataObject;
    private HealthBarController localData;
    private BloodCounter score;
        
    public float fallSpeed = 3;
    public float lifeTime = 0;
    public float bloodWorth = 5f;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.down* fallSpeed;
        dataObject = GameObject.Find("VisualizedHealthBar");
        localData = dataObject.GetComponent<HealthBarController>();

		dataObject = GameObject.FindGameObjectWithTag ("ScoreText");
		score = dataObject.GetComponent<BloodCounter> ();
    }

    void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player1")
        {
            localData.GainBloodBy(bloodWorth);
            Destroy(gameObject);
        }
    }
}
