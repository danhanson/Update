using UnityEngine;
using System.Collections;

public class ConsoleChoices : MonoBehaviour {
	
	public bool isPlus = false;
	public bool isEnabled;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseEnter() {
		if (isEnabled) {
			GetComponent<TextMesh> ().fontSize += 20;
		}
	}
	
	void OnMouseExit() {
		if (isEnabled) {
			GetComponent<TextMesh> ().fontSize -= 20;
		}
	}
	
	void OnMouseUp() {
		if (isPlus) {
			PlayerPrefs.SetInt ("Offset", PlayerPrefs.GetInt ("Offset") + 514);
		} else {
			PlayerPrefs.SetInt ("Offset",PlayerPrefs.GetInt ("Offset") - 514);
		}
	}
}