using UnityEngine;
using System.Collections;

public class BloodCounter : MonoBehaviour {

	public enum People {Man, Woman, Child};
	private static System.Collections.Generic.Dictionary<People, float> peopleToBlood
		= new System.Collections.Generic.Dictionary<People, float> ()
	{
		{People.Man, 5.5f},
		{People.Woman, 4.9f},
		{People.Child, 2.5f}
	};

	private float bloodAmount, score, multipler;

	public BloodCounter ()	
	{
		bloodAmount = 0;
		score = 0;
		multipler = 1;
	}

	public int GetScore ()
	{
		return (int) score;
	}

	public float GetBloodAmount ()
	{
		return bloodAmount;
	}

	public void SetBloodMultipler (float multipler)
	{
		this.multipler = multipler;
	}

	public void AddBlood (People type)
	{
		float bloodFromType = peopleToBlood [type];
		bloodAmount += bloodFromType;
		score += bloodFromType * multipler;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
