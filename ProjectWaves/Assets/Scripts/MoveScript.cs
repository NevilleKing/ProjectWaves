using UnityEngine;


/// Simply moves the current game object

public class MoveScript : MonoBehaviour
{
	
	/// Object speed

	public Vector2 speed = new Vector2(10, 10);

	/// Moving direction

	public Vector2 direction = new Vector2(0, 1);
	
	private Vector2 movement;
	
	void Update()
	{
		//Movement
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
	}
	
	void FixedUpdate()
	{
        GetComponent<Rigidbody>().velocity = movement;
	}
}