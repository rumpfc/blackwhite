using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour
{
	public bool Moving;
	public PlayerMovement PlayerMovementRef;

	private GameObject ObjectToMove;
	private Vector3 relTransform;

	void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			if (hit.collider != null)
			{
				if (hit.collider.gameObject.GetComponent<Taggable>().Movable)
				{
					ObjectToMove = hit.collider.gameObject;
					relTransform = ObjectToMove.transform.position - transform.position;

					if (relTransform.magnitude >= 0.1 || relTransform.magnitude <= 0.7)
					{
						if (Moving)
						{
							Moving = false;
						}
						else
						{
							if (ObjectToMove.transform.position.y - transform.position.y <= 0.2f && ObjectToMove.transform.position.y - transform.position.y >= -0.2f)
							{
								Moving = true;
								PlayerMovementRef.moving = false;
							}
						}
					}
				}
			}
		}

		if (Moving)
		{
			ObjectToMove.transform.position = transform.position + relTransform;
		}
	}
}