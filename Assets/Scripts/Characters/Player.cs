using UnityEngine;
using System.Collections;
using Update;

namespace Update.Characters {
	public class Player : MovingCharacter {

		// capture the keypress from the frame
		public void Update(){
			bool keydown = Input.GetKeyDown (KeyCode.Space);
			if (keydown)
				DoAction ();
		}

		protected override Movement GetMovement(){
			float horiz = Input.GetAxis ("Horizontal");
			float vert = Input.GetAxis("Vertical");
			return MovementExtension.ToMovement (horiz, vert);
		}

		public void MoveTo(Vector pos){
			Debug.Log("MOVE TO"+pos.ToString());
			Index = pos;
		}
	}
}
