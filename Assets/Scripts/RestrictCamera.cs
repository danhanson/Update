using UnityEngine;
using System.Collections;

public class RestrictCamera : MonoBehaviour {

	public float left;
	public float right;
	public float top;
	public float bottom;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = base.transform.parent.position;
		base.transform.position = new Vector3 (Mathf.Clamp (pos.x, left, right), Mathf.Clamp (pos.y, bottom, top), pos.z);
	}
}
