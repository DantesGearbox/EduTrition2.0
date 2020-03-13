using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
	public SVGImage icon;
	private Food foodInSlot; //The UI holds the whole item, this is slightly inefficient

	public void AddItem(Food food)
	{
		foodInSlot = food;

		icon.sprite = foodInSlot.UISprite;
		icon.color = Color.white;
		icon.enabled = true;
	}

	public void ClearSlot()
	{
		foodInSlot = null;

		icon.sprite = null;
		icon.color = Color.white;
		icon.enabled = false;
	}

	public void EatFood()
	{
		if (foodInSlot == null) return;
		foodInSlot.Eat();
	}
}
