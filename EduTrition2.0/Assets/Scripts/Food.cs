using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
	public SpriteRenderer mapSpriteRenderer;
	public Sprite UISprite;
	public Sprite mapSprite;
	new public string name = "New food";
	public string description = "A food item";

	public List<NutritionalRestorationValue> nutritionalValues;

	private void Start()
	{
		mapSpriteRenderer.sprite = mapSprite;
	}

	public void Eat()
	{
		GameEvents.instance.EatFoodEvent(this);
	}
}

[System.Serializable]
public class NutritionalRestorationValue
{
	public NutrientTypes nutrientType;
	public int amountRestored;
}
