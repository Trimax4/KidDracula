using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BloodCounter : MonoBehaviour {

	[SerializeField]
	public Text scoreText;

	public float bloodConsumed, score, multipler;
	private ShareDataScript sharedDataObjectScript;
	private bool isUpdating;

	public BloodCounter ()	
	{
		score = 0;
		multipler = 1;
		bloodConsumed = 0;
		isUpdating = true;
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

	public void resetBloodCounter () {
		isUpdating = false;
		sharedDataObjectScript.bloodConsumed = 0;	
	}

	// Use this for initialization
	void Start () {
		scoreText.text = "0";
		sharedDataObjectScript = GameObject.FindGameObjectWithTag ("shared_data_object").GetComponent<ShareDataScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isUpdating) {
			scoreText.text = sharedDataObjectScript.bloodConsumed.ToString ();
		}
	}
}
