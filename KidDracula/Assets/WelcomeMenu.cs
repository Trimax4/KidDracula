using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class WelcomeMenu : MonoBehaviour {

	[SerializeField]
	public Text endButtonText;

	public void startGame () {
		SceneManager.LoadScene ("GameScreen");
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
