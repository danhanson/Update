using UnityEngine;
using System.Collections;

public class PauseMenuChoices : MonoBehaviour {

	public bool isQuit = false;
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
		if (isQuit) {
			Application.Quit();
		}
	}
}