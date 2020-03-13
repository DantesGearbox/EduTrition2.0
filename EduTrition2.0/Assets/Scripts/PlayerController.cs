using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private float moveSpeed = 5f;
	private Vector2 movement;

	private Rigidbody2D rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	
	void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Food food = collision.GetComponent<Food>();
		if (food == null) { return; }

		GameEvents.instance.PickUpFoodEvent(food);
		food.gameObject.SetActive(false);
	}

	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
	}
}
