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
			flashLightPos = Camera.main.ScreenToWorldPoint((Input.touches[0].position + Input.touches[1].position) / 2);

			showFlashlight(flashLightPos, Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.touches[0].position), Camera.main.ScreenToWorldPoint(Input.touches[1].position))/2f);
			//showFlashlight(flashLightPos, 1f);
		} else if(Input.GetMouseButton(1)) {
			flashLightPos = Camera.main.ScreenToWorldPoint((Input.mousePosition));

			showFlashlight(flashLightPos, 2f);
		} else {
			flashlight.SetActive(false);
		}
	}

	private void showFlashlight(Vector3 pos, float size) {
		flashlight.SetActive(true);
		gameObject.transform.position = new Vector3(pos.x, pos.y, -10);
		gameObject.GetComponent<Camera> ().orthographicSize = size;
		flashlight.transform.localScale = new Vector3 (size, size, size);
	}
}