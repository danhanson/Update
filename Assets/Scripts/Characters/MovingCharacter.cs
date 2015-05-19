using UnityEngine;
using System.Collections;
using Update.Map;

namespace Update.Characters {
	/*
	 * A class for animating characters
	 */
	[RequireComponent (typeof (Animator))]
	public abstract class MovingCharacter : Character {

		private Vector lastIndex;

		private Vector LastIndex {
			get { return lastIndex; }
			set { lastIndex = value; }
		}

		private Movement movement;

		public Movement Movement {
			get { return movement; }
			internal set {
				if(value != movement){
					FaceDirection(value);
				}
				Tile next = Tile.get (Index + value.DirectionVector());
				if(next && next.character)
					movement = Movement.STANDING;
				 else
					movement = value;
			}
		}
		private Animator anim;
		public float speed; // speed in tiles per fixedupdate

		public override void Start () {
			base.Start ();
			Movement = Movement.STANDING;
			lastIndex = Index;
			Tile.get (lastIndex).character = this;
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
			bool suc = t.OnEnter (this);
			if (suc)
				t.character = this;
			return suc;
		}

		protected void Stand(){
			LastIndex = Index;
			UpdateMovement ();
		}

		protected void Left(){
			if (transform.position.x - LastIndex.X <= -1) {
				LastIndex += new Vector (-1, 0);
				LandOnTile();
				UpdateMovement ();
			} else {
				transform.Translate(-speed,0,0);
			}
		}

		protected void Right(){
			if (transform.position.x - LastIndex.X >= 1) {
				LastIndex += new Vector (1, 0);
				LandOnTile();
				UpdateMovement ();
			} else {
				transform.Translate(speed,0,0);
			}
		}

		protected void Up(){
			if (transform.position.y - LastIndex.Y >= 1) {
				LastIndex += new Vector (0, 1);
				LandOnTile();
				UpdateMovement ();
			} else {
				transform.Translate(0,speed,0);
			}
		}

		protected void Down(){
			if (transform.position.y - LastIndex.Y <= -1) {
				LastIndex += new Vector (0, -1);
				LandOnTile();
				UpdateMovement ();
			} else {
				transform.Translate(0,-speed,0);
			}
		}

		public void FaceDirection(Movement m){
			switch(m){
				case(Movement.STANDING): return;
				case(Movement.DOWN):
			 		anim.CrossFade("StandDown",0);
					break;
				case(Movement.RIGHT):
					anim.CrossFade("StandRight",0);
					break;
				case(Movement.LEFT):
					anim.CrossFade("StandLeft",0);
					break;
				case(Movement.UP):
					anim.CrossFade("StandUp",0);
					break;
			}
			facing = m;
		}

		private void UpdateAnimation(){
			anim.SetInteger("Horizontal",movement.Horizontal());
			anim.SetInteger("Vertical",movement.Vertical());
		}

		public virtual void FixedUpdate () {
			switch(Movement){
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

		public override void OnAction(Character c){
			FaceDirection(MovementExtension.ToMovement(c.Index - Index));
			base.OnAction(c);
		}

		// Called after every animation
		protected void UpdateMovement(){
			Movement = GetMovement ();
			UpdateAnimation ();
			if (movement != Movement.STANDING) {
				facing = movement;
			}
			// we want to short circuit the predicate when the character stands
			// so that we don't call OnExit and OnEnter callbacks unless the
			// character is moving. DON'T 'OPTIMIZE' IT by removing the check for
			// this.Moving

			if (movement == Movement.STANDING || !EnterTile () || !ExitTile()) {
				movement = Movement.STANDING;
			}
		}

		protected abstract Movement GetMovement();
	}
}
