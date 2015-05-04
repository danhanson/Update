using System;
using Update.Map;

namespace Update.Characters
{
	public abstract class Character : InMap
	{
		public Movement facing;

		public Vector FacingTowards(){
			return facing.DirectionVector () + index;
		}

		// do an action on this character
		public virtual void OnAction(Character o){
			// do nothing
			print ("OWW YOU HIT ME!");
		}

		public virtual void Start(){
			print ("start");
			tile ().character = this;
		}
	}
}
