using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class WelcomeMenu : MonoBehaviour {

	[SerializeField]
	public Text endButtonText;
	public float startDelay;

	private void StartGame () {
		SceneManager.LoadScene ("GameScreen");
	}

	public void InvokeToStartGame () {
		Invoke ("StartGame", startDelay);
	}

	public void EndGame () {
		endButtonText.text = "No Way...";
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
