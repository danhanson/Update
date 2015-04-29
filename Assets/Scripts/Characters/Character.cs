using UnityEngine;
using System.Collections;
using Update.Map;

namespace Update.Characters {

	/*
	 * A class for animating characters
	 */
	[RequireComponent (typeof (Animator))]
	public abstract class Character : MonoBehaviour {


		public Movement movement { get; internal set; }
		private Animator anim;
		public Vector index { get; internal set; }
		public Movement facing { get; internal set; }
		public float speed; // speed in tiles per fixedupdate

		public Character(){
			movement = Movement.STANDING;
		}

		public virtual void Start () {
			anim = GetComponent<Animator>();
			index = new Vector (
				(int)transform.position.x,
				(int)transform.position.y
			);
			facing = Movement.DOWN;
		}

		protected virtual void Action(){
			Vector v = index + facing.DirectionVector ();
			Tile.Map [v.X, v.Y].OnAction (this);
		}

		protected virtual void LandOnTile(){
			Tile t = Tile.Map [index.X, index.Y];
			if (t == null) {
				return;
			}
			t.OnLand (this);
		}

		protected virtual bool ExitTile(){
			Tile t = Tile.Map [index.X, index.Y];
			if (t == null) {
				return false;
			}
			return t.OnExit (this);
		}

		protected virtual bool EnterTile(){
			Vector dst = movement.DirectionVector() + index;
			Tile t = Tile.Map [dst.X, dst.Y];
			if (t == null) {
				return false;
			}
			return t.OnEnter (this);
		}

		protected void Stand(){
			Vector3 pos = gameObject.transform.position;
			index = new Vector((int)pos.x, (int)pos.y);
			UpdateMovement ();
		}

		protected void Left(){
			if (transform.position.x - index.X <= -1) {
				index += new Vector (-1, 0);
				LandOnTile();
				UpdateMovement ();
			} else {
				transform.Translate(-speed,0,0);
			}
		}

		protected void Right(){
			if (transform.position.x - index.X >= 1) {
				index += new Vector (1, 0);
				LandOnTile();
				UpdateMovement ();
			} else {
				transform.Translate(speed,0,0);
			}
		}

		protected void Up(){
			if (transform.position.y - index.Y >= 1) {
				index += new Vector (0, 1);
				LandOnTile();
				UpdateMovement ();
			} else {
				transform.Translate(0,speed,0);
			}
		}

		protected void Down(){
			if (transform.position.y - index.Y <= -1) {
				index += new Vector (0, -1);
				LandOnTile();
				UpdateMovement ();
			} else {
				transform.Translate(0,-speed,0);
			}
		}

		private void UpdateAnimation(){
			anim.SetInteger("Horizontal",movement.Horizontal());
			anim.SetInteger("Vertical",movement.Vertical());
		}

		public virtual void FixedUpdate () {
			switch(movement){
			case Movement.STANDING: Stand(); break;
			case Movement.LEFT: Left(); break;
			case Movement.DOWN: Down(); break;
			case Movement.RIGHT: Right(); break;
			case Movement.UP: Up(); break;
			}
		}

		// Called after every animation
		private void UpdateMovement(){
			movement = GetMovement ();
			UpdateAnimation ();
			if (movement != Movement.STANDING) {
				facing = movement;
			}
			// we want to short circuit the predicate when the character stands
			// so that we don't call OnExit and OnEnter callbacks unless the
			// character is moving. DON'T 'OPTIMIZE' IT by removing the check for
			// this.Moving

			if (movement == Movement.STANDING || !ExitTile () || !EnterTile ()) {
				movement = Movement.STANDING;
			}

			if (GetAction ()) {
				Action ();
			}
		}

		public abstract bool GetAction();

		public abstract Movement GetMovement();
	}
}
