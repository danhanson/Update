using UnityEngine;
using UnityEngine.Events;

using System.Collections;
using Update.Characters;

namespace Update.Map {
	/*
	 * a script to be attached to game objects that represent map tiles
	 */
	[System.Serializable]
	[RequireComponent (typeof (SpriteRenderer))]
	public class Tile : AbstractTileBehavior {

		// maps indices to tiles, is horrible and hacky so I should change it or something
		public static TileMap Map = new TileMap(31,31);
		
		public Character character { get; internal set; }

		// called when a character begins heading towards this tile
		// returns true if entry succeeds, otherwise returns false
		public override bool OnEnter (Character c){
			if (character != null) {
				return false;
			}
			character = c;
			bool enter = true;
			foreach (TileBehavior t in gameObject.GetComponents<TileBehavior> ()) {
				enter = enter && t.OnEnter (c);
			}
			return enter;
		}

		// called when a character begins exiting to another tile
		// returns true if exit succeeds, otherwise returns false
		public override bool OnExit (Character c){
			bool exit = true;
			foreach (TileBehavior t in gameObject.GetComponents<TileBehavior>()) {
				exit  = exit && t.OnExit (c);
			}
			if (exit) {
				character = null;
			}
			return exit;
		}
		// when character presses action button on or towards tile
		public override void OnAction (Character c){
			if (character != null) {
				character.Action (c);
			}
			foreach (TileBehavior t in gameObject.GetComponents<TileBehavior>()) {
				t.OnAction(c);
			}
		}

		public override void OnLand (Character c){
			// do nothing
		}

		public virtual void Awake(){
			// get the tiles position and insert it into the map
			// this is backwards from what one would expect, which
			// is for the map to determine where the tile are placed,
			// but it makes it easier to make the maps in unity
			Map[index] = this;
		}
	}
}
