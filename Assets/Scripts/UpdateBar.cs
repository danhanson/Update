using UnityEngine;
using System.Collections;
	
public class UpdateBar : MonoBehaviour {
	public float barDisplay;
	public Vector2 pos = new Vector2(20,40);
	public Vector2 size = new Vector2(60,20);
	public Texture2D emptyTex;
	public Texture2D fullTex;
	public int lastTime = 0;

	void OnGUI() {
		//draw the background:
		GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
		GUI.Box(new Rect(0,0, size.x, size.y), emptyTex);
		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0,0, size.x * barDisplay, size.y));
		GUI.Box(new Rect(0,0, size.x, size.y), fullTex);
		GUI.EndGroup();
		GUI.EndGroup();
	}

	void Update() {
		int tempTime=0;
		try{
		 tempTime= PlayerPrefs.GetInt ("TimePassed");
		}catch{
			//Don't need to do anything
		}
		tempTime = tempTime + (int)Time.time - lastTime;
		lastTime = (int)Time.time;
		PlayerPrefs.SetInt ("TimePassed", tempTime);
		barDisplay = tempTime*0.00009920634f;
		if (barDisplay >= 1) {
			//End the game
		}
	}

}
