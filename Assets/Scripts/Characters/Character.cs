using System;
using Update.Map;

namespace Update.Characters
{
	public abstract class Character : InMap
	{
		
		public override Vector Index {
			get { return base.Index; }
			set {
				Tile.get(Index).character = null;
				Tile.get(value).character = this;
				base.Index = value;
			}
		}

		public Movement facing;

		public Vector FacingTowards(){
			return facing.DirectionVector () + Index;
		}

		// do an action on this character
		public virtual void OnAction(Character o){
			// do nothing
		}

		public virtual void Start(){
			tile ().character = this;
		}
	}
}
