using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Intro : MonoBehaviour
{
	public Animator PlayerAnim;
	public GameObject[] Texts;

	public GameObject Me;
	public GameObject Myself;

	void Start()
	{
		StartCoroutine(intro());
	}

	IEnumerator intro()
	{
		foreach(GameObject t in Texts)
		{
			t.SetActive(true);

			yield return new WaitForSeconds(4);

			t.SetActive(false);
		}

		PlayerAnim.SetTrigger("JumpRight");

		Me.SetActive(true);
		Myself.SetActive(true);

		yield return new WaitForSeconds(3);

		Application.LoadLevel(Application.loadedLevel + 1);
	}
}