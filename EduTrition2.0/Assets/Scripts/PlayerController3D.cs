using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
	private float moveSpeed = 40f;
	private Vector3 movement;

	private Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}
	
	void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.z = Input.GetAxisRaw("Vertical");
	}

	private void OnTriggerEnter(Collider other)
	{
		Food food = other.gameObject.GetComponent<Food>();
		if (food == null) { return; }

		GameEvents.instance.PickUpFoodEvent(food);
		food.gameObject.SetActive(false);
	}

	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
	}
}
