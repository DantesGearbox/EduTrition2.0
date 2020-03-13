using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class StatusBar : MonoBehaviour
{
	public NutrientTracker nutrientTracker;
	public Text statusTitleTextElement;
	public Image mask;
	public Image fill;

	private void Start()
	{
		SetStatusTitle();
		GetCurrentFill();
	}

	private void Update()
    {
		GetCurrentFill();
    }

	private void GetCurrentFill()
	{
		float currentOffset = nutrientTracker.current - nutrientTracker.minimum;
		float maximumOffset = nutrientTracker.maximum - nutrientTracker.minimum;
		float fillAmount = currentOffset / maximumOffset;
		mask.fillAmount = fillAmount;

		fill.color = nutrientTracker.nutrient.color;
	}

	private void SetStatusTitle()
	{
		statusTitleTextElement.text = nutrientTracker.nutrient.name + " Bar";
	}
}
