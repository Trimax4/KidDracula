using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ObstacleScript : MonoBehaviour
{

    public float fallSpeed = 30;
    public float randNum = 0;
    public float lifeTime = 0;
    public GameObject dataObject;
    public Timer localData;

    void Start()
    {
        dataObject = GameObject.Find("Timer");
        localData = dataObject.GetComponent<Timer>();
        GetComponent<Rigidbody2D>().velocity = Vector2.down * fallSpeed;
    }
    void Update()
    {
        if(localData.checkPoint() == true)
        {
            fallSpeed += .1f;
        }
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
