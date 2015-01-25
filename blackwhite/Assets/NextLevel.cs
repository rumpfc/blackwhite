using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.collider2D.tag == "Player")
		{
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
}