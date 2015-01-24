using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public void loadScene(int level)
	{
		Application.LoadLevel (level);
	}
}
