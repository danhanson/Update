
using UnityEngine;
using System.Collections;
using Update.Action;
using Update.Characters;
using Update;

public class Action_Rebecca : LevelAction {
	
	public string actionName2;

	// NOTE: DO NOT EXCESS MakeSad in the delegate or else you will get
	// a null reference exception
	public Action_Rebecca() : base(delegate(){
		RebeccaTinel n = GetComponent<RebeccaTinel>();
		if (actionName2 == "makeBusy"){
			//print ("wtf");
			n.setBusy(true);
			PlayerPrefs.SetString("Robby","true");
		}
	}){}
}
