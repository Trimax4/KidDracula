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
	public float dieThreshold = 5; // in percentage
	public int currentHealth, bleedingSpeed;
	private float initY, maxX, minX, currentX;
	private BloodCounter scoreText;
	private Player_movement playerScript;
	private bool isBelowThreshold = false;

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
		currentHealth = (int) ((float) currentHealth + healthSpan * percentage / 100);

		if (currentHealth > healthSpan) {
			currentHealth = healthSpan;
		}
	}

	public void BleedBy (float percentage)
	{
		currentHealth = (int) ((float) currentHealth - healthSpan * percentage / 100);

		if (currentHealth < 0) {
			currentHealth = 0;
		}
	}

	/*  private and pre-defined */

	// Use this for initialization
	void Start () {
		initY = healthBarTransform.localPosition.y;
		maxX = healthBarTransform.localPosition.x + healthBarTransform.rect.width;
		minX = healthBarTransform.localPosition.x;

		currentHealth = healthSpan;
		bleedingSpeed = defaultBleedingSpeed;
		scoreText = GameObject.FindGameObjectWithTag ("ScoreText").GetComponent<BloodCounter> ();

		playerScript = GameObject.FindGameObjectWithTag ("Player1").GetComponent<Player_movement> ();
	}

	private void Bleed () {
		BleedBy ((float) bleedingSpeed / healthSpan * 100);
	}

	private void VisualizeHealth () {
		currentX = minX + (maxX - minX) * (healthSpan - currentHealth) / healthSpan;
		healthBarTransform.localPosition = new Vector3 (currentX, initY);

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

		if (currentHealth < 1) {
			playerScript.Die ();
		}

		if (100f * currentHealth / healthSpan < dieThreshold) {
			if (!isBelowThreshold) {
				playerScript.BarelyDie ();
				isBelowThreshold = true;
			}
		} else {
			if (isBelowThreshold) {
				isBelowThreshold = false;
				playerScript.Revive ();
			}
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
