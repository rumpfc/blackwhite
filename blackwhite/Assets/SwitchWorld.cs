using UnityEngine;
using System.Collections;

public class SwitchWorld : MonoBehaviour
{
	public GameObject PlayerWhite;
	public GameObject PlayerBlack;
	public Camera MainCamera;
	public Camera FlashlightCamera;

	void Update()
	{
		if (Input.touchCount == 1f)
		{
			if (Input.touches[0].phase == TouchPhase.Began)
			{
				
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