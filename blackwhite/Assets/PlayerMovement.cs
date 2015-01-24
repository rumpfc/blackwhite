using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float Speed = 3;

	public GameObject PlayerWhite;
	public GameObject PlayerBlack;

	private bool moving;
	private Vector3 targetPos;
	private bool blockedLeft;
	private bool blockedRight;
	private bool climbableRight;
	private bool climbableLeft;
	private bool canJump = true;

	private float dist
	{
		get { return targetPos.x - transform.position.x; }
	}

	public void canClimbRight()
	{
		climbableRight = true;
	}

	public void canClimbLeft()
	{
		climbableLeft = true;
	}

	public void collidedLeft()
	{
		if (moving && dist < 0)
		{
			blockedLeft = true;
		}
	}

	public void collidedRight()
	{
		if (moving && dist > 0)
		{
			blockedRight = true;
		}
	}

	public void unblockedRight()
	{
		blockedRight = false;
		climbableRight = false;
	}

	public void unblockedLeft()
	{
		blockedLeft = false;
		climbableLeft = false;
	}

	void Update()
	{
		if (climbableRight && moving && dist > 0)
		{
			//rigidbody2D.velocity = new Vector3(0, 4, 0);
			if (canJump)
			{
				jump();
			}
		}

		if (climbableLeft && moving && dist < 0)
		{
			//rigidbody2D.velocity = new Vector3(0, 4, 0);
			if (canJump)
			{
				jump();
			}
		}

		if (Input.GetMouseButtonUp(0))
		{
			targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if ((dist < 0 && !blockedLeft) || (dist > 0 && !blockedRight))
			{
				moving = true;
				GetComponent<Animator>().SetTrigger("Start");
			}
		}

		if (moving)
		{
			if (dist > 0.1f)
			{
				if (!blockedRight)
				{
					transform.Translate(new Vector3(Speed, 0, 0) * Time.deltaTime);
					PlayerWhite.transform.localScale = new Vector3(1, 1, 1);
					PlayerBlack.transform.localScale = new Vector3(1, 1, 1);
				}
				else
				{
					Debug.Log("blockedRight");
					StopWalking();
				}
			}
			else if (dist < -0.1f)
			{
				if (!blockedLeft)
				{
					transform.Translate(new Vector3(-Speed, 0, 0) * Time.deltaTime);
					PlayerWhite.transform.localScale = new Vector3(-1, 1, 1);
					PlayerBlack.transform.localScale = new Vector3(-1, 1, 1);
				}
				else
				{
					Debug.Log("blockedRight");
					StopWalking();
				}
			}
			else
			{
				StopWalking();
			}
		}
	}

	void jump()
	{
		canJump = false;
		GetComponent<Rigidbody2D>().isKinematic = true;
		if (PlayerWhite.transform.localScale.x == 1)
		{
			GetComponent<Animator>().SetTrigger("JumpRight");
		}
		else
		{
			GetComponent<Animator>().SetTrigger("JumpLeft");
		}
	}

	void stopJump()
	{
		if (PlayerWhite.transform.localScale.x == 1)
		{
			transform.Translate(new Vector3(1.125f, 1.001f, 0));
		}
		else
		{
			transform.Translate(new Vector3(-1.125f, 1.001f, 0));
		}
		GetComponent<Rigidbody2D>().isKinematic = false;
		//rigidbody2D.velocity = new Vector2(0, -0.2f);
		canJump = true;
	}

	public void StopWalking()
	{
		Debug.Log("StopWalking() called");
		moving = false;
		GetComponent<Animator>().SetTrigger("Stop");
	}
}
