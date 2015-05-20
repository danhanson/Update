
using UnityEngine;
using System.Collections;
using Update.Action;
using Update.Characters;
using Update;

public class Action_Owens : LevelAction {
	
	// NOTE: DO NOT EXCESS MakeSad in the delegate or else you will get
	// a null reference exception
	public Action_Owens() : base(delegate(){
		FatherOwens n = GetComponent<FatherOwens>();
		if (actionName == "markFirstSermon"){
			n.setFirstSermon(true);
		} else if (actionName == "markSecondSermon"){
			n.setSecondSermon(true);
		} else if (actionName == "makeBusy"){
			n.setBusy(true);
			//For debugging
			//PlayerPrefs.SetInt("TimePassed",1600);
		} else if (actionName == "makeNotBusy"){
			n.setBusy(false);
		} else if (actionName == "addRep"){
			n.setReputation(5);
			PlayerPrefs.SetInt("Owens_Rep",1);
		} else if (actionName == "subRep"){
			n.setReputation(-5);
			PlayerPrefs.SetInt ("Owens_Rep",-1);
		} else if (actionName == "hideNPC2"){
			// hide Michael and Father
			GameObject.Find("Michael Casey _ 2").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Father Owens _ 2").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Mayor _ 2").GetComponent<Mayor>().setEnd(true);
			PlayerPrefs.SetString("outcome","peaceful");
		} else if (actionName == "hideNPC3"){
			// hide Michael, Father, and Mayor
			GameObject.Find("Michael Casey _ 2").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Father Owens _ 2").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Mayor _ 2").GetComponent<SpriteRenderer>().enabled = false;
			PlayerPrefs.SetString("outcome","bloodbath");
		} else if (actionName == "death"){
			//End the game
			//GameObject.Find ("Gunshot").gameObject.transform.GetChild(0).gameObject.SetActive(true);
			//GameObject.Find ("Gunshot").GetComponent<AudioSource>().Play();
			Application.LoadLevel(6);
		}
	}){}
}
