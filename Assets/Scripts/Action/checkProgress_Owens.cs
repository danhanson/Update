using UnityEngine;
using System.Collections;
using Update.Action;
using Update.Characters;

public class checkProgress_Owens : UpdateQuery
{

	public string toCheck;

	public override string Apply(){
		FatherOwens npc = GameObject.Find("Father Owens").GetComponent<FatherOwens>();
		if (toCheck == "first sermon"){
			if (npc.getFirstSermon()){return "true";}
			return "false";
		} else if (toCheck == "second sermon"){
			if (npc.getSecondSermon()){return "true";}
			return "false";
		}
		return "false";
	}
}
