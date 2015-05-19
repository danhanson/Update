using UnityEngine;
using System.Collections;

public class PauseMenuChoices_Save : PauseMenuChoices
{
	public void OnMouseUp(){
		GameObject obj = GameObject.Find ("Player");
		PlayerPrefs.SetInt ("level", Application.loadedLevel);
		PlayerPrefs.SetInt ("x", (int)obj.transform.position.x);
		PlayerPrefs.SetInt ("y", (int)obj.transform.position.y);
		print ("saved");
	}
}

