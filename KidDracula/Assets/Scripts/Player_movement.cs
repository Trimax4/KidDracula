using UnityEngine;
using System.Collections;

public class Player_movement : MonoBehaviour {

    public float resetSpeed = 4f;
	public Animator animator;
	public GameObject bloodObject;
	public RectTransform rectTransform;
    private float speed;
           
	// Use this for initialization
	void Start () {
        speed = resetSpeed;
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
  
}
