using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public void loadScene(string level)
	{
		Application.LoadLevel (level);
	}

	public void loadCredits()
	{
		Application.LoadLevel ("Credits");
	}

	public void gameStart()
	{
		Application.LoadLevel ("Intro");
	}
}
