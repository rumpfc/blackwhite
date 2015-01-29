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
			Animator textAnim = t.GetComponent<Animator>();
			if(textAnim != null)
				textAnim.SetTrigger("blend");

			t.SetActive(true);

			yield return new WaitForSeconds(3);
			if(textAnim != null)
				textAnim.SetTrigger("blend");

			yield return new WaitForSeconds(1);
			t.SetActive(false);
		}

		PlayerAnim.SetTrigger("JumpRight");

		Me.GetComponent<Animator> ().SetTrigger ("blend");
		Myself.GetComponent<Animator> ().SetTrigger ("blend");
		Me.SetActive(true);
		Myself.SetActive(true);

		yield return new WaitForSeconds(3);

		Application.LoadLevel(Application.loadedLevel + 1);
	}
}