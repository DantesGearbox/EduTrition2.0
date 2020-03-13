using UnityEngine;
using System.Collections.Generic;

public class NutrientStatus : MonoBehaviour
{
	public List<NutrientTracker> nutrientTrackers = new List<NutrientTracker>();

	public List<StatusBar> statusBars = new List<StatusBar>();

	public Transform statusBarContainer;
	public GameObject nutrientBarPrefab;

	private void Start()
	{
		foreach (Nutrient nutrient in ActiveNutrientTypes.instance.nutrients)
		{
			NutrientTracker tracker = new NutrientTracker(nutrient);
			nutrientTrackers.Add(tracker);

			GameObject obj = Instantiate(nutrientBarPrefab, statusBarContainer);
			StatusBar statusBar = obj.GetComponent<StatusBar>();
			statusBar.nutrientTracker = tracker;

			statusBars.Add(statusBar);
		}

		GameEvents.instance.OnEatFood += UpdateNutrientLevels;
	}

	private void UpdateNutrientLevels(Food food)
	{
		foreach(NutritionalRestorationValue value in food.nutritionalValues)
		{
			foreach(NutrientTracker tracker in nutrientTrackers)
			{
				if(value.nutrientType == tracker.nutrient.nutrientType)
				{
					tracker.current += value.amountRestored;
				}
			}
		}
	}
	
	private void OnDestroy()
	{
		GameEvents.instance.OnEatFood -= UpdateNutrientLevels;
	}
}
