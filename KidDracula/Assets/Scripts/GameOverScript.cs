using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	[SerializeField]
	public Text endButtonText;
	public float delayStart;
	public int countToLeave;
	private static string[] sayings = new string[] {
		"No way...",
		"R u sure?",
		"Try again.",
		"Err 404"
	};

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

	private string GetRandomSaying () {
		Random.seed = ((int) Time.time) % 11;
		return sayings [Random.Range (0, sayings.Length)];
	}

	public void EndGame () {
		if (countToLeave > 0) {
			endButtonText.text = GetRandomSaying ();
			countToLeave--;
		} else {
			Application.Quit ();
		}
	}
}
