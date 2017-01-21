using UnityEngine;


/// Simply moves the current game object

public class MoveScript : MonoBehaviour
{
	
	/// Object speed

	public Vector3 speed = new Vector3(10, 10, 10);

	/// Moving direction

	public Vector3 direction = new Vector3(0, 0, -1);
	
	private Vector3 movement;
	
	void Update()
	{
		//Movement
		movement = new Vector3(
			speed.x * direction.x,
			speed.y * direction.y,
            speed.z * direction.z);
	}
	
	void FixedUpdate()
	{
        GetComponent<Rigidbody>().velocity = movement;
	}
}