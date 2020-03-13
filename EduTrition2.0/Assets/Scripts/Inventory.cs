using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	public int space = 32;
	public List<Food> foodInInventory = new List<Food>();

	private void Start()
	{
		GameEvents.instance.OnPickUpFood += OnPickUpFood;
		GameEvents.instance.OnEatFood += OnEatFood;
	}

	private void OnEatFood(Food food)
	{
		foodInInventory.Remove(food);
		GameEvents.instance.InventoryChangedEvent();
	}

	private void OnPickUpFood(Food food)
	{
		if (CanAddItem())
		{
			foodInInventory.Add(food);
			GameEvents.instance.InventoryChangedEvent();
		}
	}

	private bool CanAddItem()
	{
		if (foodInInventory.Count >= space)
		{
			Debug.Log("Not enough room");
			return false;
		}

		return true;
	}

	private void OnDestroy()
	{
		GameEvents.instance.OnPickUpFood -= OnPickUpFood;
		GameEvents.instance.OnEatFood -= OnEatFood;
	}
}
