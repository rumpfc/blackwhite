using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	private Vector3 targetPos;
	private float dist;
	private bool moving;

	void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			moving = true;
		}

		if (moving)
		{
			dist = targetPos.x - transform.position.x;

			if (dist > 0.1f)
			{
				transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime);
			}
			else if (dist < -0.1f)
			{
				transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime);
			}
			else
			{
				moving = false;
			}
		}
	}
}