using UnityEngine;
using UnityEngine.Events;

namespace Update.Dialogue
{
	// displayes a dialogue box then moves on to its child;
	[System.Serializable]
	public class Talk : Dialogue
	{
		public string label;
		public string text;
		public Sprite portrait;

		public override void Apply ()
		{
			print ("TALK APPLY");
			if(portrait != null)
				manager.SetPortraitSprite (portrait);
			if (next == null)
				manager.AddDialogue (label, text, manager.Quit);
			else
				manager.AddDialogue (label, text, next);
		}
	}
}

