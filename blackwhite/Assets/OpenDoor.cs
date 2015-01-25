using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	public Animator animator;

	void OnTriggerStay2D(Collider2D other) {
		animator.Play ("doorOpened");
	}
	
	public void OnTriggerExit2D(Collider2D other) {
		animator.Play ("doorClosed");
	}
}
