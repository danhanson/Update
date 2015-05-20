
using UnityEngine;
using System.Collections;
using Update.Action;
using Update.Characters;
using Update;

public class Action_Owens : LevelAction {
	
	public string actionName2;

	// NOTE: DO NOT EXCESS MakeSad in the delegate or else you will get
	// a null reference exception
	public Action_Owens() : base(delegate(){
		FatherOwens n = GetComponent<FatherOwens>();
		if (actionName2 == "markFirstSermon"){
			n.setFirstSermon(true);
		} else if (actionName2 == "markSecondSermon"){
			n.setSecondSermon(true);
		} else if (actionName2 == "makeBusy"){
			n.setBusy(true);
			//For debugging
			//PlayerPrefs.SetInt("TimePassed",1600);
		} else if (actionName2 == "makeNotBusy"){
			n.setBusy(false);
		} else if (actionName2 == "addRep"){
			n.setReputation(5);
			PlayerPrefs.SetInt("Owens_Rep",1);
		} else if (actionName2 == "subRep"){
			n.setReputation(-5);
			PlayerPrefs.SetInt ("Owens_Rep",-1);
		} else if (actionName2 == "hideNPC2"){
			// hide Michael and Father
			GameObject.Find("Michael Casey _ 2").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Father Owens _ 2").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Mayor _ 2").GetComponent<Mayor>().setEnd(true);
			PlayerPrefs.SetString("outcome","peaceful");
		} else if (actionName2 == "hideNPC3"){
			// hide Michael, Father, and Mayor
			GameObject.Find("Michael Casey _ 2").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Father Owens _ 2").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Mayor _ 2").GetComponent<SpriteRenderer>().enabled = false;
			PlayerPrefs.SetString("outcome","bloodbath");
		} else if (actionName2 == "death"){
			//End the game
			//GameObject.Find ("Gunshot").gameObject.transform.GetChild(0).gameObject.SetActive(true);
			//GameObject.Find ("Gunshot").GetComponent<AudioSource>().Play();
			Application.LoadLevel(6);
		}
	}){}
}
