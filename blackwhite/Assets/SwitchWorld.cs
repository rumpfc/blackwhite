﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwitchWorld : MonoBehaviour
{
	public GameObject PlayerWhite;
	public GameObject PlayerBlack;

	public GameObject ColliderLeft;
	public GameObject ColliderRight;

	public SpriteRenderer RendereWhite;
	public SpriteRenderer RendereBlack;

	public Camera MainCamera;
	public Camera FlashlightCamera;

	public GameObject Panel;

	public PlayerMovement playerMovement;

	public float minSwipeDeltaY;

	private Vector2 startPos;

	private bool canSwitch = true;

	public float minSwipeDistX;
	public float minSwipeDistY;

	public bool whiteWorld = true;

	void Update()
	{
		if (canSwitch)
		{
			if (Input.touchCount > 0) 
             
         {
             
             Touch touch = Input.touches[0];
             
             
             
             switch (touch.phase) 
                 
             {
                 
             case TouchPhase.Began:
 
                 startPos = touch.position;
                 
                 break;
                 
                 
                 
             case TouchPhase.Ended:
 
                     float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
 
                     if (swipeDistVertical > minSwipeDistY) 
                         
                     {
                         
                         float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
                         
                         if (swipeValue > 0)//up swipe
 
                            changeWorld();
                         
                         else if (swipeValue < 0){}//down swipe
 
                             //Shrink ();
                         
                     }
                     
                     float swipeDistHorizontal = (new Vector3(touch.position.x,0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
                     
                     if (swipeDistHorizontal > minSwipeDistX) 
                         
                     {
                         
                         float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
                         
                         if (swipeValue > 0){}//right swipe
                             
                             //MoveRight ();

						 else if (swipeValue < 0) { }//left swipe
                             
                             //MoveLeft ();
                         
                     }
                 break;
             }
         }

			if (Input.GetKeyDown(KeyCode.Space))
			{
				StartCoroutine(changeWorld());
			}
		}
	}

	IEnumerator changeWorld()
	{
		canSwitch = false;

		Panel.GetComponent<Animator>().SetTrigger("ChangeWorldTrigger");

		if (Panel.GetComponent<Image>().color.r == 1f)
		{
			Panel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
		}
		else
		{
			Panel.GetComponent<Image>().color = new Color(1, 1, 1, 0);
		}

		yield return new WaitForSeconds(0.5f);

		if (MainCamera.cullingMask == (1 << 9 | 1 << 0))
		{
			MainCamera.cullingMask = 1 << 8 | 1 << 0;
			FlashlightCamera.cullingMask = 1 << 9;
			ColliderLeft.layer = 8;
			ColliderRight.layer = 8;

			PlayerWhite.GetComponent<Collider2D>().enabled = true;
			PlayerBlack.GetComponent<Collider2D>().enabled = false;

			RendereBlack.color = new Color(1, 1, 1, 0);
			RendereWhite.color = new Color(1, 1, 1, 1);

			MainCamera.backgroundColor = Color.white;
			FlashlightCamera.backgroundColor = Color.black;

			whiteWorld = true;

			foreach (GameObject g in GameObject.FindGameObjectsWithTag("Dynamic"))
			{
				g.layer = 8;
			}
		}
		else
		{
			MainCamera.cullingMask = 1 << 9 | 1 << 0;
			FlashlightCamera.cullingMask = 1 << 8;

			ColliderLeft.layer = 9;
			ColliderRight.layer = 9;

			PlayerWhite.GetComponent<Collider2D>().enabled = false;
			PlayerBlack.GetComponent<Collider2D>().enabled = true;

			RendereBlack.color = new Color(1, 1, 1, 1);
			RendereWhite.color = new Color(1, 1, 1, 0);

			MainCamera.backgroundColor = Color.black;
			FlashlightCamera.backgroundColor = Color.white;

			whiteWorld = false;

			foreach (GameObject g in GameObject.FindGameObjectsWithTag("Dynamic"))
			{
				g.layer = 9;
			}
		}

		yield return new WaitForSeconds(0.5f);

		canSwitch = true;
	}
}