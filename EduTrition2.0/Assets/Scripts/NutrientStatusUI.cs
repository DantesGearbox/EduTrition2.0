using System.Collections.Generic;
using UnityEngine;

public class NutrientStatusUI : MonoBehaviour
{
	public NutrientStatus nutrientStatus;

	private void Start()
	{
		GameEvents.instance.OnNutrientTrackersChanged += UpdateNutrientStatusUI;
	}

	private void UpdateNutrientStatusUI()
	{
		//for (int i = 0; i < nutrientStatus.statusBars.Count; i++)
		//{
		//	nutrientStatus.statusBars[i].nutrientTracker.current = nutrientStatus.nutrientTrackers[i].current;
		//}
	}

	private void OnDestroy()
	{
		GameEvents.instance.OnNutrientTrackersChanged -= UpdateNutrientStatusUI;
	}
}
