using UnityEngine;
using System.Collections;
using Update;
using Update.Characters;

/*
 * A tile that teleports the player to the specified level at the
 * specified index when the player lands on it
 */
namespace Update.Map {
	public class DoorTile : Tile {

		protected const string PLAYER_NAME = "Player";

		public int Level;
		public Vector EntryPoint;


		public override void OnLand(Character c) {
			if (c.gameObject.name != PLAYER_NAME)
				return;
			DontDestroyOnLoad (transform.root.gameObject);
			Application.LoadLevel(Level);
		}

		public virtual void OnLevelWasLoaded(int level){
			if (this.Level == level) {
				GameObject obj = GameObject.Find (PLAYER_NAME);
				Player p = obj.GetComponent<Player>();
				p.MoveTo(EntryPoint);
				Destroy (transform.root.gameObject);
			}
		}
	}
}
