using UnityEngine;
using System.Collections;
using Update.Map;

namespace Update.Characters {
	/*
	 * A class for animating characters
	 */
	[RequireComponent (typeof (Animator))]
	public abstract class MovingCharacter : Character {

		private new Vector index;

		public Movement movement { get; internal set; }
		private Animator anim;
		public float speed; // speed in tiles per fixedupdate

		public MovingCharacter(){
			movement = Movement.STANDING;
		}
		public override void Start () {
			base.Start ();
			index = base.index;
			anim = GetComponent<Animator>();
		}

		protected virtual void DoAction(){
			Vector v = FacingTowards();
			Tile t = Tile.get (v);
			if (t == null)
				return;
			t.OnAction (this);
		}

		protected virtual void LandOnTile(){
			tile ().OnLand (this);
		}

		protected virtual bool ExitTile(){
			return tile ().OnExit (this);
		}

		protected virtual bool EnterTile(){
			Vector dst = FacingTowards();
			Tile t = Tile.get (dst);
			if(t == null){
				return false;
			}
			return t.OnEnter (this);
		}

		protected void Stand(){
			index = base.index;
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

		public virtual void OnDisable(){
			anim.speed = 0;
		}

		public virtual void OnEnable(){
			if(anim != null)	// anim may not have been set yet
				anim.speed = 1;
		}

		// Called after every animation
		protected void UpdateMovement(){
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
		}

		protected abstract Movement GetMovement();
	}
}
