using UnityEngine;
using System.Collections;

public class Paralax : MonoBehaviour
{
	public float Multiplicator;
	public GameObject MainCamera;

	void Update()
	{
		transform.position = new Vector3( MainCamera.transform.position.x, MainCamera.transform.position.y, 3) * Multiplicator;
	}
}