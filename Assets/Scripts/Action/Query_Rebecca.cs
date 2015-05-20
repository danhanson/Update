using Update.Action;
using Update.Characters;
using System;
using UnityEngine;

public class Query_Rebecca : UpdateQuery {

	public string query;

	public override string Apply(){
		RebeccaTinel npc = GetComponent<RebeccaTinel>();
		if (query == "checkIsBusy") {
			if (npc.getBusy ()) {
				return "true";
			} else {
				return "false";
			}
		}
		return "true";
	}
	
}
