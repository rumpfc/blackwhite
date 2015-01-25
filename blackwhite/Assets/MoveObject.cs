using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour
{
	public bool Moving;
	public GameObject ColliderL;
	public GameObject ColliderR;
	public GameObject PlayerWhite;
	public PlayerMovement PlayerMovementRef;

	public GameObject OnjectColliderW;
	public GameObject OnjectColliderB;

	private GameObject ObjectToMove;
	private Vector3 relTransform;
	private bool isClimbable;

	void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			if (hit.collider != null && hit.collider.gameObject != null && hit.collider.gameObject.GetComponent<Taggable>() != null)
			{
				if (hit.collider.gameObject.GetComponent<Taggable>().Movable)
				{
					ObjectToMove = hit.collider.gameObject;
					relTransform = ObjectToMove.transform.position - transform.position;

					if (relTransform.magnitude <= 2)
					{
						if (Moving)
						{
							Moving = false;
							ObjectToMove.GetComponent<Taggable>().Climbable = isClimbable;
							StartCoroutine(stopPlayer());
							ObjectToMove.GetComponent<Rigidbody2D>().isKinematic = false;
							gameObject.GetComponent<PlayerMovement>().canJump = true;

							foreach (GameObject g in GameObject.FindGameObjectsWithTag("MovingObjectCollider"))
							{
								g.SetActive(false);
							}

							ColliderL.SetActive(true);
							ColliderR.SetActive(true);

						}
						else
						{
							if (ObjectToMove.transform.position.y - transform.position.y <= 0.2f && ObjectToMove.transform.position.y - transform.position.y >= -0.2f)
							{

								Moving = true;
								PlayerMovementRef.StopWalking();
								isClimbable = ObjectToMove.GetComponent<Taggable>().Climbable;
								ObjectToMove.GetComponent<Taggable>().Climbable = false;
								StartCoroutine(stopPlayer());
								ObjectToMove.GetComponent<Rigidbody2D>().isKinematic = true;
								gameObject.GetComponent<PlayerMovement>().canJump = false;

								foreach (GameObject g in GameObject.FindGameObjectsWithTag("MovingObjectCollider"))
								{
									g.SetActive(true);
								}

								if (ObjectToMove.transform.position.x - transform.position.x > 0)
								{
									ColliderR.SetActive(false);
									ColliderL.SetActive(true);
								}
								else
								{
									ColliderR.SetActive(true);
									ColliderL.SetActive(false);
								}


							}
						}
					}
				}
			}
		}

		if (Moving)
		{
			ObjectToMove.transform.position = transform.position + new Vector3(1.2f, 0, 0);
		}


	}

	IEnumerator stopPlayer()
	{
		GetComponent<PlayerMovement>().StopWalking();
		yield return new WaitForEndOfFrame();
		GetComponent<PlayerMovement>().StopWalking();
	}
}