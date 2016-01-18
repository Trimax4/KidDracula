using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {

	private float alpha;
	public float step = 0.15f;
	public bool isFading = false;

	public void StartFade () {
		isFading = true;
	}

	void OnGUI() {
		if (isFading) {
			alpha += step;

			if (alpha > 1) {
				alpha = 1;
				isFading = false;
			}
		}

		GUI.depth = -9999999;
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), new RenderTexture (Screen.width, Screen.height, 24));
	}

	// Use this for initialization
	void Start () {
		alpha = 0;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
