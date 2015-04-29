using UnityEngine;
using System.Collections;
using Update.Characters;

namespace Update.Map {

	/*
	 * For attaching events to tiles
	 */
	[System.Serializable]
	public class TileBehavior : AbstractTileBehavior {
		// called when a character begins heading towards this tile
		// returns true if entry succeeds, otherwise returns false
		public override bool OnEnter (Character c){
			return true;
		}
		
		// called when a character begins exiting to another tile
		// returns true if exit succeeds, otherwise returns false
		public override bool OnExit (Character c){
			return true;
		}

		// called after a character enters the tile
		public override void OnLand (Character c){
			// do nothing
		}
		
		// when character presses action button on or towards tile
		public override void OnAction (Character c){
			// do nothing
		}
	}
}
