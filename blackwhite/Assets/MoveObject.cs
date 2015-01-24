using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour
{
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			if (hit.collider != null)
			{
				Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
			}
		}
	}
}