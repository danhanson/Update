
using UnityEngine;
using System.Collections;
using Update.Action;
using Update.Characters;
using Update;

public class makeBusy : RecordedAction {

	public bool busy = true;
	
	// NOTE: DO NOT EXCESS MakeSad in the delegate or else you will get
	// a null reference exception
	public makeBusy() : base(delegate(){
		FatherOwens n = GameObject.Find("Father Owens").GetComponent<FatherOwens>();
		n.isBusy = busy;
	}){}
}
