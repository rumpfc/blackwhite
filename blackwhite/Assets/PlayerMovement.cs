using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	private Vector3 targetPos;
	private bool moving;
	private bool blockedLeft;
	private bool blockedRight;

	private float dist {
		get { return targetPos.x - transform.position.x; }
	}

	public void collidedLeft(){
		if(moving && dist < 0) {
			moving = false;
			blockedLeft = true;
		}
	}

	public void collidedRight(){
		if(moving && dist > 0) {
			moving = false;
			blockedRight = true;
		}
	}

	public void unblockedRight() {
		blockedRight = false;
	}

	public void unblockedLeft() {
		blockedLeft = false;
	}

	void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if((dist < 0 && !blockedLeft) || (dist > 0 && !blockedRight)) {
				moving = true;
			}
		}

		if (moving)
		{
			if (dist > 0.1f)
			{
				transform.Translate(new Vector3(3, 0, 0) * Time.deltaTime);
			}
			else if (dist < -0.1f)
			{
				transform.Translate(new Vector3(-3, 0, 0) * Time.deltaTime);
			}
			else
			{
				moving = false;
			}
		}
	}
}
