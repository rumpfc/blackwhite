using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwitchWorld : MonoBehaviour
{
	public GameObject PlayerWhite;
	public GameObject PlayerBlack;

	public GameObject ColliderLeft;
	public GameObject ColliderRight;

	public SpriteRenderer RendereWhite;
	public SpriteRenderer RendereBlack;

	public Camera MainCamera;
	public Camera FlashlightCamera;

	public GameObject Panel;

	public PlayerMovement playerMovement;

	public bool canSwitch = true;

	public float minSwipeDistY;
	private Vector2 startPos;
	private Vector2 endPos;


	void Update()
	{
		if (canSwitch)
		{
			if (Input.GetMouseButtonDown(0))
			{
				startPos = Input.mousePosition;
			}

			if (Input.GetMouseButtonUp(0))
			{
				endPos = Input.mousePosition;
				Debug.Log(startPos.y - endPos.y > minSwipeDistY);

				if (startPos.y - endPos.y > Screen.height / 2)
				{
					if ((startPos.y - endPos.y) / (startPos.x - endPos.x) > 1)
					{
						StartCoroutine(changeWorld());
					}
				}
			}

			if (Input.GetKeyDown(KeyCode.Space))
			{
				Debug.Log("meh");
				StartCoroutine(changeWorld());
			}
		}
	}

	IEnumerator changeWorld()
	{
		canSwitch = false;

		Panel.GetComponent<Animator>().SetTrigger("ChangeWorldTrigger");

		if (Panel.GetComponent<Image>().color.r == 1f)
		{
			Panel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
		}
		else
		{
			Panel.GetComponent<Image>().color = new Color(1, 1, 1, 0);
		}

		yield return new WaitForSeconds(0.5f);

		if (MainCamera.cullingMask == (1 << 9 | 1 << 0))
		{
			MainCamera.cullingMask = 1 << 8 | 1 << 0;
			FlashlightCamera.cullingMask = 1 << 9;
			ColliderLeft.layer = 8;
			ColliderRight.layer = 8;

			PlayerWhite.GetComponent<Collider2D>().enabled = true;
			PlayerBlack.GetComponent<Collider2D>().enabled = false;

			RendereBlack.color = new Color(1, 1, 1, 0);
			RendereWhite.color = new Color(1, 1, 1, 1);

			MainCamera.backgroundColor = Color.white;
			FlashlightCamera.backgroundColor = Color.black;

			foreach (GameObject g in GameObject.FindGameObjectsWithTag("Dynamic"))
			{
				g.layer = 8;
			}
		}
		else
		{
			MainCamera.cullingMask = 1 << 9 | 1 << 0;
			FlashlightCamera.cullingMask = 1 << 8;

			ColliderLeft.layer = 9;
			ColliderRight.layer = 9;

			PlayerWhite.GetComponent<Collider2D>().enabled = false;
			PlayerBlack.GetComponent<Collider2D>().enabled = true;

			RendereBlack.color = new Color(1, 1, 1, 1);
			RendereWhite.color = new Color(1, 1, 1, 0);

			MainCamera.backgroundColor = Color.black;
			FlashlightCamera.backgroundColor = Color.white;

			foreach (GameObject g in GameObject.FindGameObjectsWithTag("Dynamic"))
			{
				g.layer = 9;
			}
		}

		yield return new WaitForSeconds(0.5f);

		canSwitch = true;
	}
}