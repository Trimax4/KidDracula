using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {

    public Texture2D tex;
	private float alpha = 0f;
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

        GUI.depth = -99999;
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), tex);
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}
