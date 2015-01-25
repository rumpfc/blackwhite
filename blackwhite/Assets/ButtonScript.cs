using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour
{

	public Animator animator;

	void OnTriggerEnter()
	{
		/*
		if (!GetComponent<AudioSource>().isPlaying)
		{
			GetComponent<AudioSource>().Play();
		}
		 */
	}

	void OnTriggerStay2D(Collider2D other)
	{
		animator.Play("buttonPressed");
	}

	public void OnTriggerExit2D(Collider2D other)
	{
		animator.Play("buttonUnpressed");
	}

}