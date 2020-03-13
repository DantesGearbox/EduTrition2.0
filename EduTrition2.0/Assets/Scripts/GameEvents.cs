using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
	#region Singleton
	public static GameEvents instance;

	private void Awake()
	{
		instance = this;
	}
	#endregion

	public event Action<Food> OnPickUpFood;
	public void PickUpFoodEvent(Food food)
	{
		if(OnPickUpFood != null)
		{
			Debug.Log("OnPickUpFood");
			OnPickUpFood.Invoke(food);
		}
	}

	public event Action OnInventoryChanged;
	public void InventoryChangedEvent()
	{
		if (OnInventoryChanged != null)
		{
			Debug.Log("OnInventoryChanged");
			OnInventoryChanged.Invoke();
		}
	}

	public event Action<Food> OnEatFood;
	public void EatFoodEvent(Food food)
	{
		if (OnEatFood != null)
		{
			Debug.Log("OnEatFood");
			OnEatFood.Invoke(food);
		}
	}

	public event Action OnNutrientTrackersChanged;
	public void NutrientTrackersChangedEvent()
	{
		Debug.Log("OnNutrientLevelChanged");
		if (OnNutrientTrackersChanged != null)
		{
			Debug.Log("OnNutrientLevelChanged");
			OnNutrientTrackersChanged.Invoke();
		}
	}
}