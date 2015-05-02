
using UnityEngine;
using Update.Characters;

namespace Update.Map {

	// used to attach callbacks to Tile objects. Consider a character moving from a Tile "Start" to an
	// adjacent Tile "Dest", then the callbacks are called in this order:
	// 
	//		start.OnExit() -> dest.OnEnter() -> dest.OnLand()
	//
	// both OnExit and OnEnter return a bool to indicate whether the character is blocked or is allowed to 
	// continue moving
	public abstract class AbstractTileBehavior : InMap {
		// called when a character begins heading towards this tile
		// returns true if entry succeeds, otherwise returns false
		public abstract bool OnEnter (Character c);
		
		// called when a character begins exiting to another tile
		// returns true if exit succeeds, otherwise returns false
		public abstract bool OnExit (Character c);

		// called after a character moves into the tile and 
		public abstract void OnLand (Character c);
		
		// when character presses action button on or towards tile
		public abstract void OnAction (Character c);
	}
}
