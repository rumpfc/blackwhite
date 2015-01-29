using UnityEngine;
using System.Collections;

public class MainCameraMovement : MonoBehaviour {

	public GameObject Player;
	//public GameObject Background;

	private Vector3 bgStartPos;
	private Vector3 velocity = Vector3.zero;
	private float smoothTime = 0.3f;

	public float minX;
	public float minY;
	public float maxX;
	public float maxY;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newCamPos = Player.transform.position;

		newCamPos.x = Mathf.Clamp (newCamPos.x, minX, maxX);
		newCamPos.y = Mathf.Clamp (newCamPos.y, minY, maxY);
		newCamPos.z = transform.position.z;
		transform.position =  Vector3.SmoothDamp(transform.position, newCamPos, ref velocity, smoothTime);
	}
}
