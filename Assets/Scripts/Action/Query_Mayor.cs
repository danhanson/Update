using Update.Action;
using Update.Characters;
using System;
using UnityEngine;

public class Query_Mayor : UpdateQuery {

	public string query;

	public override string Apply(){
		Mayor npc = GetComponent<Mayor>();
		if (query == "checkStatus") {
			if (npc.getEnd()) {
				return "after";
			} else if (npc.getMiddle()) {
				return "middle";
			} else {
				return "before";
			}
		}
		return "true";
	}
	
}
