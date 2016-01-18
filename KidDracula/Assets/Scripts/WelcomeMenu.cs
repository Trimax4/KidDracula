using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class WelcomeMenu : MonoBehaviour {

	[SerializeField]
	public Text endButtonText;
	public float startDelay;
	public int countToLeave = 3;
	private static string[] sayings = new string[] {
		"No way...",
		"R u sure?",
		"Try again.",
		"Err 404"
	};

	private void StartGame () {
		SceneManager.LoadScene ("GameScreen");
	}

	private string GetRandomSaying () {
		Random.seed = ((int) Time.time) % 11;
		return sayings [Random.Range (0, sayings.Length)];
	}

	public void InvokeToStartGame () {
		Invoke ("StartGame", startDelay);
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
