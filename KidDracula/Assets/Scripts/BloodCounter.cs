using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BloodCounter : MonoBehaviour {

	[SerializeField]
	public Text scoreText;

	public float bloodConsumed, score, multipler;
	private ShareDataScript sharedDataObjectScript;

	public BloodCounter ()	
	{
		score = 0;
		multipler = 1;
		bloodConsumed = 0;
	}

	public int GetScore ()
	{
		return (int) score;
	}

	public float GetBloodAmount ()
	{
		return bloodConsumed;
	}

	public void SetBloodMultipler (float multipler)
	{
		this.multipler = multipler;
	}

	public void AddBlood (float bloodAmount)
	{
		bloodConsumed += bloodAmount;
		score += bloodAmount * multipler;
		sharedDataObjectScript.bloodConsumed = bloodConsumed;
	}

	// Use this for initialization
	void Start () {
		scoreText.text = "0";
		sharedDataObjectScript = GameObject.FindGameObjectWithTag ("shared_data_object").GetComponent<ShareDataScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = sharedDataObjectScript.bloodConsumed.ToString ();
	}
}
