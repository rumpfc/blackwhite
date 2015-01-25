using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public void loadScene(int level)
	{
		Application.LoadLevel (level);
	}

	public void loadMainMenu()
	{
		Debug.Log ("load main menu");
		Application.LoadLevel (0);
	}
}
