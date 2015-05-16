
using UnityEngine;
using System.Collections;
using Update.Action;
using Update.Characters;
using Update;

public class changeReputation : RecordedAction {
	
	public int reputation;
	
	// NOTE: DO NOT EXCESS MakeSad in the delegate or else you will get
	// a null reference exception
	public changeReputation() : base(delegate(){
		FatherOwens n = GameObject.Find("Father Owens").GetComponent<FatherOwens>();
		n.reputation += reputation;
	}){}
}
