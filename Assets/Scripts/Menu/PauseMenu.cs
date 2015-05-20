using UnityEngine;
using System.Collections;
using Update.Characters;
using System;
using Update;

public class PauseMenu : MonoBehaviour
{

	private bool pressed = false;
	private bool menuShowing = false;
	private int childCount;

	// Use this for initialization
	void Start ()
	{	
		//PlayerPrefs.DeleteAll ();
		childCount = gameObject.transform.childCount;
		for (int i = 0; i < childCount; i++) {
			gameObject.transform.GetChild(i).gameObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape) && !pressed) {
			pressed = true;
			ToggleMenu();
		}
		if (Input.GetKeyUp (KeyCode.Escape) && pressed) {
			pressed = false;
		}
	}

	void ToggleMenu(){
		menuShowing = !menuShowing;
		transform.GetComponentInParent<Player> ().speed = menuShowing.CompareTo(true) * 0.125f * -1.000f;
		childCount = gameObject.transform.childCount;
		for (int i = 0; i < childCount; i++) {
			print("child: " + menuShowing);
			gameObject.transform.GetChild(i).gameObject.SetActive(menuShowing);
		}
	}
}

