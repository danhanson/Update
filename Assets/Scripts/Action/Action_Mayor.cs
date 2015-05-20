
using UnityEngine;
using System.Collections;
using Update.Action;
using Update.Characters;
using Update;

public class Action_Mayor : LevelAction {
	
	public string actionName2;

	// NOTE: DO NOT EXCESS MakeSad in the delegate or else you will get
	// a null reference exception
	public Action_Mayor() : base(delegate(){
		Mayor n = GetComponent<Mayor>();
		if (actionName2 == "showNPCs"){
			GameObject.Find("Michael Casey _ 2").GetComponent<SpriteRenderer>().enabled=true;
			GameObject.Find("Father Owens _ 2").GetComponent<SpriteRenderer>().enabled=true;
			n.setMiddle(true);
		}
	}){}
}
