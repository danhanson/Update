using Update.Action;
using Update.Characters;
using System;
using UnityEngine;

public class Query_Owens : UpdateQuery {

	public string query;

	public override string Apply(){
		FatherOwens npc = GetComponent<FatherOwens>();
		if (query == "checkIsBusy") {
			if (npc.getBusy ()) {
				return "true";
			} else {
				return "false";
			}
		} else if (query == "checkFirst") {
			if (npc.getFirstSermon ()) {
				return "true";
			} else {
				return "false";
			}
		} else if (query == "checkSecond") {
			if (!npc.getSecondSermon () && (PlayerPrefs.GetInt ("TimePassed") > 1029)) {
				return "false";
			} else {
				return "true";
			}
		} else if (query == "checkBusyReset1") {
			if (!npc.getSecondSermon () && (PlayerPrefs.GetInt ("TimePassed") > 1029)) {
				return "true";
			} else {
				return "false";
			}
		} else if (query == "checkKnowledge") {
			if (PlayerPrefs.HasKey ("Robby")) {
				print("has key");
				if (PlayerPrefs.GetString ("Robby") == "true") {
					return "true";
				} else {
					return "false";
				}
			} else {
				return "false";
			}
		} else if (query == "checkOutcome") {
			return PlayerPrefs.GetString ("outcome");
		} else if (query == "checkStanding") {
			if (PlayerPrefs.GetInt ("Owens_Rep") > 0) {
				return "good";
			} else {
				return "bad";
			}
		}
		return "true";
	}
	
}
