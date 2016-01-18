using UnityEngine;
using System.Collections;

public class Player_movement : MonoBehaviour {

    public float resetSpeed = 4f;
	public Animator animator;
    private GameObject dataObject;
    private float speed;
    private SoundManager sound;
           
	// Use this for initialization
	void Start () {
        speed = resetSpeed;

        dataObject = GameObject.Find("Main Camera");
        sound = dataObject.GetComponent<SoundManager>();
    }
	
	// Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.LeftArrow) && (GameObject.Find("Player").transform.position.x > GameObject.Find("Left_boundary").transform.position.x))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            speed=0f;
        }
        speed=resetSpeed;
        if (Input.GetKey(KeyCode.RightArrow)&& (GameObject.Find("Player").transform.position.x < GameObject.Find("Right_boundary").transform.position.x))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            speed=0f;
        }
        speed=resetSpeed;


    }
    
    void OnCollision2DEnter(Collider2D col)
    {
        if(col.gameObject.tag == "man")
        {
            Debug.Log("in man");
            GameObject.Find("Main Camera").GetComponent<SoundManager>().PlaySound(2);
        }
        if(col.gameObject.tag == "child")
        {
            GameObject.Find("Main Camera").GetComponent<SoundManager>().PlaySound(2);
        }
        if(col.gameObject.tag == "woman")
        {
            GameObject.Find("Main Camera").GetComponent<SoundManager>().PlaySound(1);
        }
    }

}
