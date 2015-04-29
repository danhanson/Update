
using UnityEngine;
using Update.Dialogue;
using Update.Characters;

namespace Update.Map
{
	/*
	 * 	A tile for a character to stand in
	 */
	public class CharacterTile : SolidTile
	{
		public override void OnAction(Character c)
		{
			base.OnAction (c);
			if(c is Player){
				print ("ACTION");
				Dialogue.Dialogue d = gameObject.GetComponent<Dialogue.Dialogue> ();
				if (d != null) {
					print("dialogue");
					d.Apply ();
				}
			}
		}
	}
}
