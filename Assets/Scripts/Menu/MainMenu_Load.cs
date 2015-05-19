using UnityEngine;
using System.Collections;
using Update.Characters;
using Update;

public class MainMenu_Load : MainMenu
{
	public void OnMouseUp(){
		DontDestroyOnLoad (transform.root.gameObject);
		Application.LoadLevel (PlayerPrefs.GetInt ("level"));
		//print (" Didn't Destroy");
	}

	public void OnLevelWasLoaded(int level){
		GameObject obj = GameObject.Find ("Player");
		Player p = obj.GetComponent<Player>();
		Vector EntryPoint = new Vector (PlayerPrefs.GetInt ("x"), PlayerPrefs.GetInt ("y"));
		p.MoveTo(EntryPoint);
		Destroy (transform.root.gameObject);
	}
}

