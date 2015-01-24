using UnityEngine;
using System.Collections;

public class SwitchWorld : MonoBehaviour
{
	public GameObject PlayerWhite;
	public GameObject PlayerBlack;
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
		if (MainCamera.cullingMask == 1 << 9 )
		{
			MainCamera.cullingMask = 1 << 8;
			PlayerBlack.SetActive(false);
			PlayerWhite.SetActive(true);
			MainCamera.backgroundColor = Color.black;
		}
		else
		{
			MainCamera.cullingMask = 1 << 9;
			PlayerBlack.SetActive(true);
			PlayerWhite.SetActive(false);
			MainCamera.backgroundColor = Color.white;
		}
	}
}