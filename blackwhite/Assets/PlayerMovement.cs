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
	public bool canJump = true;

	private float dist
	{
		get { return targetPos.x - transform.position.x; }
	}

	public void canClimbRight()
	{
		Debug.Log ("climb to the right");
		climbableRight = true;
	}

	public void canClimbLeft()
	{
		Debug.Log ("climb to the right");
		climbableLeft = true;
	}

	public void collidedLeft()
	{
		Debug.Log ("Collided left");
		if (moving && dist < 0)
		{
			Debug.Log ("blocked left");
			blockedLeft = true;
		}
	}

	public void collidedRight()
	{
		Debug.Log ("Collided right");
		if (moving && dist > 0)
		{
			Debug.Log ("blocked right");
			blockedRight = true;
		}
	}

	public void unblockedRight()
	{
		Debug.Log ("unblocked right");
		blockedRight = false;
		climbableRight = false;
	}

	public void unblockedLeft()
	{
		Debug.Log ("unblocked left");
		blockedLeft = false;
		climbableLeft = false;
	}

	void Update()
	{
		if (climbableRight && moving && dist > 0)
		{
			Debug.Log ("climbableRight && moving and dist > 0");
			//rigidbody2D.velocity = new Vector3(0, 4, 0);
			if (canJump)
			{
				Debug.Log ("he can jump");
				jump();
			}
		}

		if (climbableLeft && moving && dist < 0)
		{
			Debug.Log ("climbableLeft && moving && dist < 0");
			//rigidbody2D.velocity = new Vector3(0, 4, 0);
			if (canJump)
			{
				Debug.Log ("he can jump");
				jump();
			}
		}

		if (Input.GetMouseButtonUp(0))
		{
			Debug.Log ("Mouse Button up");
			targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Debug.Log ("targetPos = " + targetPos);
			if ((dist < 0 && !blockedLeft) || (dist > 0 && !blockedRight))
			{
				Debug.Log ("(dist < 0 && !blockedLeft) || (dist > 0 && !blockedRight)");
				moving = true;
				GetComponent<Animator>().SetTrigger("Start");
			}
		}

		if (moving)
		{
			Debug.Log ("I like to move it");
			if (dist > 0.1f)
			{
				Debug.Log ("dist > 0.1");
				if (!blockedRight)
				{
					Debug.Log ("not blocked right");
					transform.Translate(new Vector3(Speed, 0, 0) * Time.deltaTime);
					PlayerWhite.transform.localScale = new Vector3(1, 1, 1);
					PlayerBlack.transform.localScale = new Vector3(1, 1, 1);
				}
				else
				{
					Debug.Log("blocked right");
					StopWalking();
				}
			}
			else if (dist < -0.1f)
			{
				Debug.Log("dist < -0.1");
				if (!blockedLeft)
				{
					Debug.Log ("not blocked left");
					transform.Translate(new Vector3(-Speed, 0, 0) * Time.deltaTime);
					PlayerWhite.transform.localScale = new Vector3(-1, 1, 1);
					PlayerBlack.transform.localScale = new Vector3(-1, 1, 1);
				}
				else
				{
					Debug.Log("blocked left");
					StopWalking();
				}
			}
			else
			{
				Debug.Log ("STOOOOP");
				StopWalking();
			}
		}
	}

	void jump()
	{
		Debug.Log ("I'm jumping");
		canJump = false;
		GetComponent<Rigidbody2D>().isKinematic = true;
		if (PlayerWhite.transform.localScale.x == 1)
		{
			Debug.Log ("jumping to the right");
			GetComponent<Animator>().SetTrigger("JumpRight");
		}
		else
		{
			Debug.Log ("jumping to the left");
			GetComponent<Animator>().SetTrigger("JumpLeft");
		}
	}

	void stopJump()
	{
		Debug.Log ("finished jumping");
		if (PlayerWhite.transform.localScale.x == 1)
		{
			Debug.Log ("I jumped to the right");
			transform.Translate(new Vector3(1.125f, 1.001f, 0));
		}
		else
		{
			Debug.Log ("I jumped to the left");
			transform.Translate(new Vector3(-1.125f, 1.001f, 0));
		}
		GetComponent<Rigidbody2D>().isKinematic = false;
		//rigidbody2D.velocity = new Vector2(0, -0.2f);
		canJump = true;
	}

	public void StopWalking()
	{
		Debug.Log("I stop walking");
		moving = false;
		GetComponent<Animator>().SetTrigger("Stop");
	}
}
