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

		public override void Apply ()
		{
			print (this.transform.childCount);
			foreach (Transform child in transform) {
				Dialogue next = child.GetComponent<Dialogue>();
				manager.AddOption(child.name,next);
			}
		}
	}
}
