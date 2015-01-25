using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public void loadScene(int level)
	{
		Application.LoadLevel (level);
	}

	public void loadMainMenu()
	{
		Application.LoadLevel (0);
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
