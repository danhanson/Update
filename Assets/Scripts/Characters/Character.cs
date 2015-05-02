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
		public virtual void Action(Character o){
			// do nothing
		}

		public virtual void OnLevelWasLoaded(){
			print ("ADDED CHARACTER");
			Tile.Map [index].character = this;
		}

		public virtual void Awake(){
			OnLevelWasLoaded();
		}
	}
}
