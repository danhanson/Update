using System;
using Update.Map;
using Update.Dialogue;

namespace Update.Characters
{
	public abstract class Character : InMap, ActionListener
	{

		private Dialogue.Dialogue d;
		
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

		public virtual void OnAction(Character o){
			if(d)
				d.Apply();
		}

		public virtual void Start(){
			tile ().character = this;
			d = GetComponent<Dialogue.Dialogue>();
		}
	}
}
