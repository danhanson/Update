
using UnityEngine;
using Update.Dialogue;

namespace Update.Characters
{
	[RequireComponent (typeof (SpriteRenderer))]
	public class StationaryCharacter : Character {

		public GameObject dialogue;
		private Dialogue.Dialogue d;

		public void Start(){
			if(dialogue)
				d = dialogue.GetComponent<Dialogue.Dialogue> ();
		}

		public override void Action (Character o)
		{
			if(d)
				d.Apply ();
		}
	}
}
