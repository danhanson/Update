
using UnityEngine;
using System.Collections;
using Update.Action;
using Update.Characters;
using Update;

public class markProgress_Owens : LevelAction {
	
	public string toChange;
	
	// NOTE: DO NOT EXCESS MakeSad in the delegate or else you will get
	// a null reference exception
	public markProgress_Owens() : base(delegate(){
		print("I'm trying to do something");

		FatherOwens n = GameObject.Find("Father Owens").GetComponent<FatherOwens>();
		if (toChange == "firstSermon"){
			print ("I'm doing the right thing.");

			n.setFirstSermon(true);
		} else if (toChange == "secondSermon"){
			n.setSecondSermon(true);
		} else if (toChange == "firstConvo"){
			//n.setFirstConvo = true;
		}
	}){}
}
