using UnityEngine.Events;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
	public Inventory inventory;
	public Transform inventorySlotContainer;

	private InventorySlot[] slots;

	private void Start()
	{
		slots = inventorySlotContainer.GetComponentsInChildren<InventorySlot>();
		GameEvents.instance.OnInventoryChanged += UpdateInventoryUI;
	}

	void UpdateInventoryUI()
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if(i < inventory.foodInInventory.Count)
			{
				slots[i].AddItem(inventory.foodInInventory[i]);
			}
			else
			{
				slots[i].ClearSlot();
			}
		}
	}

	private void OnDestroy()
	{
		GameEvents.instance.OnInventoryChanged -= UpdateInventoryUI;
	}
}
