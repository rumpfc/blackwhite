using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public bool Moving;
	public float Speed = 3;

	private Vector3 targetPos;
	private bool blockedLeft;
	private bool blockedRight;
	private bool climbableRight;
	private bool climbableLeft;
	
	private float dist {
		get { return targetPos.x - transform.position.x; }
	}

	public void canClimbRight() {
		climbableRight = true;
	}

	public void canClimbLeft() {
		climbableLeft = true;
	}

	public void collidedLeft(){
		if(Moving && dist < 0) {
			blockedLeft = true;
		}
	}

	public void collidedRight(){
		if(Moving && dist > 0) {
			blockedRight = true;
		}
	}

	public void unblockedRight() {
		blockedRight = false;
		climbableRight = false;
	}

	public void unblockedLeft() {
		blockedLeft = false;
		climbableLeft = false;
	}

	void Update()
	{
		if(climbableRight && Moving && dist > 0) {
			rigidbody2D.velocity = new Vector3(0,4,0);
		}

		if(climbableLeft && Moving && dist < 0) {
			rigidbody2D.velocity = new Vector3(0,4,0);
		}

		if (Input.GetMouseButtonUp(0))
		{
			targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if((dist < 0 && !blockedLeft) || (dist > 0 && !blockedRight)) {
				Moving = true;
			}
		}

		if (Moving)
		{
			if (dist > 0.1f)
			{
				if(!blockedRight) {
					transform.Translate(new Vector3(Speed, 0, 0) * Time.deltaTime);
				}
			} else if (dist < -0.1f)
			{
				if(!blockedLeft) {
					transform.Translate(new Vector3(-Speed, 0, 0) * Time.deltaTime);
				}
			}
			else
			{
				Moving = false;
			}
		}
	}
}
