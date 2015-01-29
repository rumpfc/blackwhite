using UnityEngine;
using System.Collections;

public class LevelButtonControl : MonoBehaviour {

	public void returnToMainMenu()
	{
		Application.LoadLevel ("MainMenu");
	}

	public void reloadLevel()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}
