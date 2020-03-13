using UnityEngine;

public enum NutrientTypes { Iodine, Iron, VitaminA, VitaminB, VitaminC, VitaminD };

[System.Serializable]
public class Nutrient
{
	public Color color;
	public NutrientTypes nutrientType = NutrientTypes.Iodine;
	public string name = "New Nutrient";
	public string description = "A nutrient";
}
