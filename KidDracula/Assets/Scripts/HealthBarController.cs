using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// contorller for the health, from [0, healthSpan] of unit

public class HealthBarController : MonoBehaviour {

	const int defaultBleedingSpeed = 2; // unit per frame
	const int healthSpan = 1000; // in unit

	[SerializeField]
	public Text healthSubtext, healthMultipler;
	public RectTransform healthBarTransform;
	private float initY, maxX, minX;
	public int currentHealth, bleedingSpeed;
	private BloodCounter scoreText;

	/*  public */

	public void SetBleedingSpeed (int bleedingSpeed)
	{
		this.bleedingSpeed = bleedingSpeed;
	}

	public int getCurrentHealth ()
	{
		return currentHealth;
	}

	public void GainBloodBy (float percentage)
	{
		currentHealth = (int) ((float) currentHealth + healthSpan * percentage);

		if (currentHealth > healthSpan) {
			currentHealth = healthSpan;
		}
	}

	public void BleedBy (float percentage)
	{
		currentHealth = (int) ((float) currentHealth - healthSpan * percentage);

		if (currentHealth < 0) {
			currentHealth = 0;
		}
	}

	/*  private and pre-defined */

	// Use this for initialization
	void Start () {
		initY = healthBarTransform.position.y;
		maxX = healthBarTransform.position.x + healthBarTransform.rect.width;
		minX = healthBarTransform.position.x;

		currentHealth = healthSpan;
		bleedingSpeed = defaultBleedingSpeed;
		scoreText = GameObject.FindGameObjectWithTag ("ScoreText").GetComponent<BloodCounter> ();
	}

	private void Bleed () {
		BleedBy ((float) bleedingSpeed / healthSpan);
	}

	private void VisualizeHealth () {
		float currentX = minX + (maxX - minX) * (healthSpan - currentHealth) / healthSpan;
		healthBarTransform.position = new Vector3 (currentX, initY);

		if (currentHealth < healthSpan / 3) {
			healthSubtext.text = "You suck!";
			UpdateMultipler (0.5f);
		} else if (currentHealth > healthSpan / 3 * 2) {
			healthSubtext.text = "Bloody Kid :)";
			UpdateMultipler (2f);
		} else {
			healthSubtext.text = "Not bad...";
			UpdateMultipler (1f);
		}

	}

	private void UpdateMultipler (float multipler)
	{
		scoreText.SetBloodMultipler (multipler);
		healthMultipler.text = multipler.ToString ("0.0") + "x";	
	}
	
	// Update is called once per frame
	void Update () {
		Bleed ();
		VisualizeHealth ();
	}
}
