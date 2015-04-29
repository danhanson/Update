
using UnityEngine;

namespace Update.Dialogue
{
	/*
	 * For when a character is talking several boxes worth
	 */
	public class MultiTalk : Dialogue
	{
		public string label;
		public string[] dialogues;
		public Sprite portrait;

		public override void Apply ()
		{
			if (null == dialogues || 0 == dialogues.Length)
				return;
			if(portrait != null)
				manager.SetPortraitSprite (portrait);
			Apply (0);
		}

		private void Apply(int i){
			manager.AddDialogue (label, dialogues [i], delegate {
				if(++i < dialogues.Length){
					Apply(i);
				} else {
					if(next != null)
						next.Apply();
					else
						manager.Quit();
				}
			});
		}
	}
}
