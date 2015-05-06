
using UnityEngine;
using Update.Dialogue;

namespace Update.Characters
{
	[RequireComponent (typeof (SpriteRenderer))]
	public class StationaryCharacter : Character {

		private Dialogue.Dialogue d;

		public override void Start(){
			base.Start ();
			d = GetComponent<Dialogue.Dialogue> ();
		}

		public override void OnAction (Character o)
		{
			if(d)
				d.Apply ();
		}
	}
}
