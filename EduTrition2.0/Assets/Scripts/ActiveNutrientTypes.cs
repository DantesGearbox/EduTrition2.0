using System.Collections.Generic;
using UnityEngine;

public class ActiveNutrientTypes : MonoBehaviour
{
	#region Singleton
	public static ActiveNutrientTypes instance;

	private void Awake()
	{
		instance = this;
	}
	#endregion

	public List<Nutrient> nutrients;
}
