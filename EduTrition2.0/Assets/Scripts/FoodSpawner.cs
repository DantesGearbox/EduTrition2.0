using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
	private int maxXSpawnRange = 100;
	private int maxZSpawnRange = 100;

	private float spawnFoodOnStartDelay = 1;
	private float spawnFoodInterval = 1;

	private bool continueFoodSpawn = true;

	private float timeBeforeMiddleIsPlaced = 10;
	public Transform playerTransform;

	public Transform foodContainer;

	public List<Food> activeFood;

	void Start()
    {
		InvokeRepeating("SpawnFood", spawnFoodOnStartDelay, spawnFoodInterval);
		maxXSpawnRange = StartScene.instance.playfieldRadius * 5;
		maxZSpawnRange = StartScene.instance.playfieldRadius * 5;
		transform.localScale = new Vector3(StartScene.instance.playfieldRadius, 0, StartScene.instance.playfieldRadius);
		StartCoroutine(PlaceMiddleOfMap());
	}

	private void SpawnFood()
	{
		if (continueFoodSpawn)
		{
			Food toBeSpawned = activeFood[Random.Range(0, activeFood.Count - 1)];
			Vector3 deltaPosition = new Vector3(Random.Range(-maxXSpawnRange, maxXSpawnRange), toBeSpawned.transform.position.y, Random.Range(-maxZSpawnRange, maxZSpawnRange));
			Vector3 spawnPosition = transform.position + deltaPosition;
			Quaternion spawnRotation = Quaternion.Euler(60, 0, 0);

			Debug.Log("Spawning food: " + toBeSpawned.name);
			Food spawnedFood = Instantiate(toBeSpawned, spawnPosition, spawnRotation);
			spawnedFood.transform.SetParent(foodContainer);
		}
	}

	IEnumerator PlaceMiddleOfMap()
	{
		yield return new WaitForSeconds(timeBeforeMiddleIsPlaced);
		transform.position = new Vector3(playerTransform.position.x, 1, playerTransform.position.z);
	}
}
