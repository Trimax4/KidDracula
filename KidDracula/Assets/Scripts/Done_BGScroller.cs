using UnityEngine;
using System.Collections;

public class Done_BGScroller : MonoBehaviour
{
	public float scrollSpeed = 0.1f;
	public float tileSizeZ;
	public GameObject repeatTile1, repeatTile2;
	private int tileIndex = 0;

	void Start ()
	{
	}

	void Update ()
	{
		transform.position += new Vector3(0, scrollSpeed * -1, 0);
		tileIndex = (int) Mathf.Abs((transform.position.y) / transform.localScale.y);
		repeatTile1.transform.localPosition = new Vector3 (
			0,
			0 + tileIndex,
			0
		);
		repeatTile2.transform.localPosition = new Vector3 (
			0,
			1 + tileIndex,
			0
		);		
	}
}