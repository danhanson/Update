using UnityEngine;
using UnityEngine.Events;

using System.Collections;
using Update.Characters;
using Update;

namespace Update.Map {
	/*
	 * a script to be attached to game objects that represent map tiles
	 */
	[System.Serializable]
	[RequireComponent (typeof (SpriteRenderer))]
	public class Tile : AbstractTileBehavior {
		
		public Character character { get; internal set; }
        public Item item { get; internal set; }

		// called when a character begins heading towards this tile
		// returns true if entry succeeds, otherwise returns false
		public override bool OnEnter (Character c){
			if (character != null) {
				return false;
			}
			bool enter = true;
			foreach (TileBehavior t in gameObject.GetComponents<TileBehavior> ()) {
				enter = enter && t.OnEnter (c);
			}
			if(enter)
				character = c;
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
				character.OnAction (c);
			} else if(item != null){
                item.OnAction(c);
            }
			foreach (TileBehavior t in gameObject.GetComponents<TileBehavior>()) {
				t.OnAction(c);
			}
		}

		public override void OnLand (Character c){
			// do nothinga
		}

		public static Tile get(Vector index){
			return GameData.map [index];
		}

		public static Tile get(int x, int y){
			return GameData.map [x, y];
		}

		public virtual void OnEnable(){
			// get the tiles position and insert it into the map
			// this is backwards from what one would expect, which
			// is for the map to determine where the tile are placed,
			// but it makes it easier to make the maps in unity
			GameData.map[Index] = this;
		}
	}
}
