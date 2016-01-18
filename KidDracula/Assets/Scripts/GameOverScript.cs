using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	public float delayStart;

	public void RestartGame () {
		SceneManager.LoadScene ("GameScreen");
	}

	public void InvokeToRestartGame () {
		Invoke ("RestartGame", delayStart);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
