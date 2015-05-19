using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public bool isTitle = false;
	public bool isQuit = false;
	public bool isEnabled;
	private float alpha = 0;
	private TextMesh current;
	private Color endcolor;
	private bool fading = true;
	
	// Use this for initialization
	void Start () {
		current = GetComponent<TextMesh>();
		endcolor = current.color;
		current.color = new Color(endcolor.r,endcolor.g,endcolor.b,0);
	}
	
	// Update is called once per frame
	void Update () {
		if (!TitleFade.fading && fading){
			StartCoroutine(FadeIn ());
		}
	}
	
	IEnumerator FadeIn() {
		yield return new WaitForSeconds (2);
		alpha += 0.005f;
		current.color = new Color(endcolor.r,endcolor.g,endcolor.b,alpha);
		if (Mathf.Abs (1 - alpha) <= 0.0001) {
			fading = false;
		}
	}

	void OnMouseEnter() {
		if (isEnabled) {
			GetComponent<TextMesh> ().fontSize += 5;
		}
	}
	
	void OnMouseExit() {
		if (isEnabled) {
			GetComponent<TextMesh> ().fontSize -= 5;
		}
	}

	void OnMouseUp() {
		if (isEnabled) {
			if (isQuit) {
				Application.Quit();
			} else {
				Application.LoadLevel(1);
			}
		}
	}
}