using UnityEngine;
using System.Collections;

public class Failure : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find ("Gunshot").GetComponent<AudioSource>().Play();
		StartCoroutine (Music ());
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	IEnumerator Music() {
		yield return new WaitForSeconds (2);
		GameObject.Find ("Music").GetComponent<AudioSource>().Play();
	}	
}