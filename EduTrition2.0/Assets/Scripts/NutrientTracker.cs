[System.Serializable]
public class NutrientTracker
{
	public int minimum = 0;
	public int maximum = 100;
	public int current = 5;

	public Nutrient nutrient;

	public NutrientTracker(int minimum, int maximum, int current, Nutrient nutrient)
	{
		this.minimum = minimum;
		this.maximum = maximum;
		this.current = current;
		this.nutrient = nutrient;
	}

	public NutrientTracker(Nutrient nutrient)
	{
		minimum = 0;
		maximum = 100;
		current = 5;
		this.nutrient = nutrient;
	}
}
