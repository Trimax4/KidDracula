using UnityEngine;
using System.Collections;

public class BloodScript : MonoBehaviour {

	[Range (0, 1f)]
	public float lifeTime;
	public float velocity;

	// Use this for initialization
	void Start () {
		Invoke ("SelfDestroy", lifeTime);
	}

	private void SelfDestroy () {
		Destroy(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (0, 0.02f, 0);
	}
}
