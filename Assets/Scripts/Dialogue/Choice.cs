using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Update.Dialogue
{

	/*
	 * This dialogue gives the player a choice. To add choices, add dialogues to the children
	 * of this gameobject
	 */
	public class Choice : Dialogue
	{
		
		public string question;
		
		public string label;

		public override void Apply ()
		{
			if (question != null) {
				manager.AddDialogue(label,question);
			}
			foreach (Transform child in transform) {
				Dialogue next = child.GetComponent<Dialogue>();
				manager.AddOption(child.name,next);
			}
		}
	}
}
