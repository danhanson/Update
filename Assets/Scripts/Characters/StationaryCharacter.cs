
using UnityEngine;
using Update.Dialogue;

namespace Update.Characters
{
	[RequireComponent (typeof (SpriteRenderer))]
	public class StationaryCharacter : Character {

		public GameObject dialogue;
		private Dialogue.Dialogue d;

		public override void Start(){
			base.Start ();
			if(dialogue)
				d = dialogue.GetComponent<Dialogue.Dialogue> ();
		}

		public override void OnAction (Character o)
		{
			if(d)
				d.Apply ();
		}
	}
}
