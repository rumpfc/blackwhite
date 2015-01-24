using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour
{

	public Animator animator;

	void OnTriggerEnter2D(Collider2D other)
	{
		animator.Play("buttonPressed");
	}

	void OnTriggerExit2D(Collider2D other)
	{
		animator.Play("buttonUnpressed");
	}

}