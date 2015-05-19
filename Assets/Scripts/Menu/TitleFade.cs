using UnityEngine;
using System.Collections;

public class TitleFade : MonoBehaviour {

	private float alpha = 0;
	private TextMesh current;
	private Color endcolor;
	static public bool fading = true;

	// Use this for initialization
	void Start () {
		current = GetComponent<TextMesh>();
		endcolor = current.color;
		current.color = new Color(endcolor.r,endcolor.g,endcolor.b,0);
	}
	
	// Update is called once per frame
	void Update () {
		if (fading) {
			StartCoroutine(FadeIn ());
		}
	}

	IEnumerator FadeIn() {
		yield return new WaitForSeconds (2.85f);
		alpha += 0.0025f;
		current.color = new Color(endcolor.r,endcolor.g,endcolor.b,alpha);
		if (Mathf.Abs (1 - alpha) <= 0.0001) {
			fading = false;
		}
	}
}
