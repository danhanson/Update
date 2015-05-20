using Update.Action;
using Update.Characters;
using System;
using UnityEngine;

public class Query_Casey : UpdateQuery {

	public string query;

	public override string Apply(){
		MichaelCasey npc = GetComponent<MichaelCasey>();
		FatherOwens owens = GameObject.Find("Father Owens _ 1").GetComponent<FatherOwens> ();
		if (query == "checkIsBusy") {
			if (npc.getBusy ()) {
				return "true";
			} else {
				return "false";
			}
		} else if (query == "checkFirst") {
			if (owens.getFirstSermon ()) {
				return "true";
			} else {
				return "false";
			}
		} else if (query == "checkSecond") {
			if (owens.getSecondSermon ()) {
				return "true";
			} else if (!owens.getSecondSermon () && (PlayerPrefs.GetInt ("TimePassed") > 1500)) {
				return "listen";
			} else {
				return "false";
			}
		} else if (query == "checkBusyReset1") {
			if (!owens.getSecondSermon () && (PlayerPrefs.GetInt ("TimePassed") > 1500)) {
				return "true";
			} else {
				return "false";
			}
		}
		return "true";
	}
	
}
