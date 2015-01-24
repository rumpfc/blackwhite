using UnityEngine;
using System.Collections;

public class MainCameraMovement : MonoBehaviour {

	public GameObject Player;
	private Vector3 velocity = Vector3.zero;
	private float smoothTime = 0.3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newCamPos = Player.transform.position;
		newCamPos.z = transform.position.z;
		transform.position =  Vector3.SmoothDamp(transform.position, newCamPos, ref velocity, smoothTime);
	}
}
