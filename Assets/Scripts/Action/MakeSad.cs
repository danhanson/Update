
using UnityEngine;
using System.Collections;
using Update.Action;
using Update.Characters;
using Update;

public class MakeSad : LevelAction {

	// NOTE: DO NOT EXCESS MakeSad in the delegate or else you will get
	// a null reference exception
	public MakeSad() : base(delegate(){
		NPC n = GameObject.Find("NPC").GetComponent<NPC>();
		n.isHappy = false;
	}){}
}
