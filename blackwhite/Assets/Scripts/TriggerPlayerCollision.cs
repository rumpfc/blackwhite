using UnityEngine;
using System.Collections;

public class TriggerPlayerCollision : MonoBehaviour
{

	public PlayerMovement movement;
	public bool right;

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.isTrigger) {
			return;
		}
		Taggable taggable = other.GetComponent<Taggable>();
		if (taggable != null && taggable.Climbable)
		{
			if (right)
			{
				movement.canClimbRight();
			}
			else
			{
				movement.canClimbLeft();
			}
		}
		else
		{
			if (right)
			{
				movement.collidedRight();
			}
			else
			{
				movement.collidedLeft();
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (right)
		{
			movement.unblockedRight();
		}
		else
		{
			movement.unblockedLeft();
		}

	}
}