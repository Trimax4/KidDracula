using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player_movement : MonoBehaviour {

    public float resetSpeed = 4f;
	public Animator animator;
    private GameObject dataObject;
    private float speed;
    private SoundManager sound;
	public GameObject bloodObject;
	public RectTransform rectTransform;
	public Renderer rend;
    private Timer time;
           
	// Use this for initialization
	void Start () {
        speed = resetSpeed;


        dataObject = GameObject.Find("Main Camera");
        sound = dataObject.GetComponent<SoundManager>();

        dataObject = GameObject.Find("Timer");
        time = dataObject.GetComponent<Timer>();
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
    void FixedUpdate()
    {

        if(time.checkPoint() == true)
        {
            GameObject.Find("Main Camera").GetComponent<SoundManager>().PlaySound(0);
        }
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

	public void Bite (string direction) {
		animator.SetTrigger ("PlayerBite" + direction);
		Vector3 offset = new Vector3 (0, 0.8f, 0);
		Vector3 rotation = new Vector3 (0, 0, 0);
		if (direction == "Left") {
			offset.x = -0.4f;	
		} else {
			offset.x = 0.3f;
			rotation.z = -45;
		}
		Instantiate (bloodObject, transform.position + offset, Quaternion.Euler (rotation));
	}

	public void BarelyDie () {
		rend.material.color = new Color (0.6f, 0.3f, 0.3f, 1);
		animator.SetTrigger ("PlayerHurt");
	}

	public void Revive () {
		rend.material.color = new Color (1, 1, 1, 1);
		animator.SetTrigger ("PlayerRevive");
	}

	public void Die () {
        GameObject.Find("Main Camera").GetComponent<SoundManager>().PlaySound(3);
        animator.SetTrigger ("PlayerHurt");
		Invoke ("LoseGame", 0.5f);
	}

	private void LoseGame () {
        SceneManager.LoadScene ("GameOverScreen");
	}
}
