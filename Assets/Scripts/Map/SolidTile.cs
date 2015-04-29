using UnityEngine;
using Update.Characters;

namespace Update.Map {
	public class SolidTile : Tile {

		public override bool OnEnter (Character c)
		{
			base.OnEnter(c);
			return false;
		}
	}
}
