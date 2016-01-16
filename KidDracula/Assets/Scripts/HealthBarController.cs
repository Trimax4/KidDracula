using UnityEngine;
using System.Collections;

// contorller for the health, from [0, healthSpan] of unit

public class HealthBarController : MonoBehaviour {

	const int defaultBleedingSpeed = 1; // unit per frame
	const int healthSpan = 1000; // in unit

	public RectTransform healthBarTransform;
	private float initY, maxX, minX;
	private int currentHealth, bleedingSpeed;

	public void SetBleedingSpeed (int bleedingSpeed)
	{
		this.bleedingSpeed = bleedingSpeed;
	}

	public int getCurrentHealth ()
	{
		return currentHealth;
	}

	public void BleedBy (float percentage)
	{
		currentHealth = (int) ((float) currentHealth - healthSpan * percentage);

		if (currentHealth < 0) {
			currentHealth = 0;
		} else if (currentHealth > healthSpan) {
			currentHealth = healthSpan;
		}
	}

	// Use this for initialization
	void Start () {
		initY = healthBarTransform.position.y;
		maxX = healthBarTransform.position.x + healthBarTransform.rect.width;
		minX = healthBarTransform.position.x;

		currentHealth = healthSpan;
		bleedingSpeed = defaultBleedingSpeed;
	}

	private void Bleed () {
		BleedBy ((float) bleedingSpeed / healthSpan);
	}

	private void VisualizeHealth () {
		float currentX = minX + (maxX - minX) * (healthSpan - currentHealth) / healthSpan;
		healthBarTransform.position = new Vector3 (currentX, initY);
	}
	
	// Update is called once per frame
	void Update () {
		Bleed ();
		VisualizeHealth ();
	}
}
