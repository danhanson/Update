using UnityEngine;
using System.Collections;
using Update.Action;
using Update.Characters;
using Update;

public class ExampleAction : UpdateAction {

	public override void Apply(){
		GameObject player = GameObject.Find ("Player");
		Player p = player.GetComponent<Player> ();
		p.Index = new Vector(5, 5);
	}
}
