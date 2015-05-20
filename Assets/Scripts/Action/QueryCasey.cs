using Update.Action;
using Update.Characters;
using System;
using UnityEngine;

public class QueryCasey : UpdateQuery {

	public override string Apply(){
		MichaelCasey npc = GetComponent<MichaelCasey>();
		FatherOwens owens = GameObject.Find("Father Owens _ 1").GetComponent<FatherOwens> ();
		if (queryName == "checkIsBusy") {
			if (npc.getBusy ()) {
				return "true";
			} else {
				return "false";
			}
		} else if (queryName == "checkFirst") {
			if (owens.getFirstSermon ()) {
				return "true";
			} else {
				return "false";
			}
		} else if (queryName == "checkSecond") {
			if (owens.getSecondSermon ()) {
				return "true";
			} else if (!owens.getSecondSermon () && (PlayerPrefs.GetInt ("TimePassed") > 1500)) {
				return "listen";
			} else {
				return "false";
			}
		} else if (queryName == "checkBusyReset") {
			if (!owens.getSecondSermon () && (PlayerPrefs.GetInt ("TimePassed") > 1500)) {
				return "true";
			} else {
				return "false";
			}
		}
		return "true";
	}
	
}
