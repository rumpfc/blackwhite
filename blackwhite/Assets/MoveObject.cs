using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour
{
	public bool Moving;
	public PlayerMovement PlayerMovementRef;

	private GameObject ObjectToMove;
	private Vector3 relTransform;
	private bool isClimbable;

	void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			if (hit.collider != null && hit.collider.gameObject != null)
			{
				if (hit.collider.gameObject.GetComponent<Taggable>().Movable)
				{
					ObjectToMove = hit.collider.gameObject;
					relTransform = ObjectToMove.transform.position - transform.position;

					if (relTransform.magnitude <= 1.5)
					{
						if (Moving)
						{
							Moving = false;
							ObjectToMove.GetComponent<Taggable>().Climbable = isClimbable;
							StartCoroutine(stopPlayer());
							ObjectToMove.GetComponent<Rigidbody2D>().isKinematic = false;
						}
						else
						{
							if (ObjectToMove.transform.position.y - transform.position.y <= 0.2f && ObjectToMove.transform.position.y - transform.position.y >= -0.2f)
							{
								Moving = true;
								PlayerMovementRef.Moving = false;
								isClimbable = ObjectToMove.GetComponent<Taggable>().Climbable;
								ObjectToMove.GetComponent<Taggable>().Climbable = false;
								StartCoroutine(stopPlayer());
								ObjectToMove.GetComponent<Rigidbody2D>().isKinematic = true;
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

	IEnumerator stopPlayer()
	{
		GetComponent<PlayerMovement>().Moving = false;
		yield return new WaitForEndOfFrame();
		GetComponent<PlayerMovement>().Moving = false;
	}
}