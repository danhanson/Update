
using UnityEngine;
using System.Collections;
using Update.Action;
using Update.Characters;
using Update;

public class MakeHappy : UpdateAction {

	public override void Apply(){
		NPC n = GetComponent<NPC>();
		n.isHappy = true;
	}
}
