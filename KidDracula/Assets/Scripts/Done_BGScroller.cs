using UnityEngine;
using System.Collections;

public class Done_BGScroller : MonoBehaviour
{
	public float scrollSpeed;
	public float tileSizeZ;
	public GameObject repeatTile1, repeatTile2;
	private int tileIndex = 0;
	private Vector3 repeatTile1Position, repeatTile2Position;

	void Start ()
	{
		repeatTile1Position = repeatTile1.transform.localPosition;
		repeatTile2Position = repeatTile1.transform.localPosition;
	}

	void Update ()
	{
		transform.position += new Vector3(0, -0.1f, 0);
		tileIndex = (int) Mathf.Abs((transform.position.y) / transform.localScale.y);
		Debug.Log (tileIndex);
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