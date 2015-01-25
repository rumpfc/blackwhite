using UnityEngine;
using System.Collections;

public class FlashlightCamera : MonoBehaviour
{
	public GameObject flashlight;

	private Vector2 flashLightPos;

	void Update()
	{
		if (Input.touchCount == 2)
		{
			flashlight.SetActive(true);

			flashLightPos = Camera.main.ScreenToWorldPoint((Input.touches[0].position + Input.touches[1].position) / 2);

			gameObject.transform.position = flashLightPos;
		}
		
		if(Input.GetMouseButton(1))
		{
			flashlight.SetActive(true);

			flashLightPos = Camera.main.ScreenToWorldPoint((Input.mousePosition));

			gameObject.transform.position = new Vector3(flashLightPos.x, flashLightPos.y, -10);
		}
		else
		{
			flashlight.SetActive(false);
		}
	}
}