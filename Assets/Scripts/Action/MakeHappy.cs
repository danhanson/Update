
using UnityEngine;
using System.Collections;
using Update.Action;
using Update.Characters;
using Update;

public class MakeHappy : RecordedAction {

	public MakeHappy() : base(delegate(){
	    NPC n = GameObject.Find("NPC").GetComponent<NPC>();
	    n.isHappy = true;
    }){}
}
