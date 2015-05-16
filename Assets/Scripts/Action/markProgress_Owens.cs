
using UnityEngine;
using System.Collections;
using Update.Action;
using Update.Characters;
using Update;

public class markProgress_Owens : RecordedAction {
	
	public string toChange;
	
	// NOTE: DO NOT EXCESS MakeSad in the delegate or else you will get
	// a null reference exception
	public markProgress_Owens() : base(delegate(){
		print("I'm trying to do something");

		FatherOwens n = GameObject.Find("Father Owens").GetComponent<FatherOwens>();
		if (toChange == "firstSermon"){
			print ("I'm doing the right thing.");

			n.firstSermon = true;
		} else if (toChange == "secondSermon"){
			n.secondSermon = true;
		} else if (toChange == "firstConvo"){
			n.firstConvo = true;
		}
	}){}
}
