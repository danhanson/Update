
using UnityEngine;
using System.Collections;
using Update.Action;
using Update.Characters;
using Update;

public class Action_Casey : LevelAction {
	
	public Action_Casey() : base(delegate(){
		MichaelCasey n = GetComponent<MichaelCasey>();
		if (actionName == "makeBusy"){
			n.setBusy(true);
		} else if (actionName == "makeNotBusy"){
			n.setBusy(false);
		} else if (actionName == "addRep"){
			n.setReputation(5);
		} else if (actionName == "subRep"){
			n.setReputation(-5);
		}
	}){}
}
