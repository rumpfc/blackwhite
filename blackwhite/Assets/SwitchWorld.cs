using UnityEngine;
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

	public float minSwipeDeltaY;

	private Vector2 startPos;

	void Update()
	{
		if (Input.touchCount == 1f)
		{
			Touch touch = Input.touches[0];

			if (touch.phase == TouchPhase.Began)
			{
				switch (touch.phase)
				{
					case TouchPhase.Began:

						startPos = touch.position;

						break;

					case TouchPhase.Ended:

						float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

						if (swipeDistVertical > minSwipeDeltaY)
						{

							float swipeValue = Mathf.Sign(touch.position.y - startPos.y);

							if (swipeValue > 0)
							{
								changeWorld();
							}
						}
						break;
				}
			}
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			changeWorld();
		}
	}

	void changeWorld()
	{
		if (MainCamera.cullingMask == 1 << 9)
		{
			MainCamera.cullingMask = 1 << 8;
			ColliderLeft.layer =  8;
			ColliderRight.layer = 8;

			PlayerWhite.GetComponent<Collider2D>().enabled = true;
			PlayerBlack.GetComponent<Collider2D>().enabled = false;

			RendereBlack.color = new Color(1, 1, 1, 0);
			RendereWhite.color = new Color(1, 1, 1, 1);

			MainCamera.backgroundColor = Color.black;
			FlashlightCamera.backgroundColor = Color.white;


		}
		else
		{
			MainCamera.cullingMask = 1 << 9;
			ColliderLeft.layer =  9;
			ColliderRight.layer = 9;

			PlayerWhite.GetComponent<Collider2D>().enabled = false;
			PlayerBlack.GetComponent<Collider2D>().enabled = true;

			RendereBlack.color = new Color(1, 1, 1, 1);
			RendereWhite.color = new Color(1, 1, 1, 0);

			MainCamera.backgroundColor = Color.white;
			FlashlightCamera.backgroundColor = Color.black;
		}
	}
}