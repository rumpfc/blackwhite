using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour
{
	public bool Moving;
	public GameObject ColliderL;
	public GameObject ColliderR;
	public GameObject PlayerWhite;
	public PlayerMovement PlayerMovementRef;
	public SwitchWorld switchWorlds;

	public GameObject OnjectColliderW;
	public GameObject OnjectColliderB;

	private GameObject ObjectToMove;
	private bool isClimbable;

	void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			bool hitWhite = hit.collider != null && hit.collider.gameObject.layer == 8;
			bool isWhite = switchWorlds == null || switchWorlds.whiteWorld;

			if (hit.collider != null && hit.collider.gameObject != null && hit.collider.gameObject.GetComponent<Taggable>() != null && (hitWhite == isWhite))
			{
				if (hit.collider.gameObject.GetComponent<Taggable>().Movable)
				{
					ObjectToMove = hit.collider.gameObject;
					float distance = Mathf.Abs(ObjectToMove.transform.position.x - transform.position.x);
					Debug.Log("Found something" + distance);

					if (distance <= 2)
					{
						if (Moving)
						{
							ReleaseObject();
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

	public void ReleaseObject()
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

	IEnumerator stopPlayer()
	{
		GetComponent<PlayerMovement>().StopWalking();
		yield return new WaitForEndOfFrame();
		GetComponent<PlayerMovement>().StopWalking();
	}
}