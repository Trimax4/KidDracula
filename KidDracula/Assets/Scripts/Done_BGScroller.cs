using UnityEngine;
using System.Collections;

public class Done_BGScroller : MonoBehaviour
{
	public float scrollSpeed;
	public float tileSizeZ;
	public GameObject repeatTile1, repeatTile2;

	private Vector3 startPosition;

	void Start ()
	{
		startPosition = transform.position;
	}

	void Update ()
	{
		transform.position += new Vector3(0, -0.1f, 0);
//		(int) Mathf.Abs (transform.position.y) % transform.localScale.y
	}
}