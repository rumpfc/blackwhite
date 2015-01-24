using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	public Animator animator;

	void OnTriggerEnter2D(Collider2D other) {
		animator.Play ("doorOpened");
	}
	
	void OnTriggerExit2D(Collider2D other) {
		animator.Play ("doorClosed");
	}
}
