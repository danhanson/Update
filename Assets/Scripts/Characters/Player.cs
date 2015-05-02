using UnityEngine;
using System.Collections;
using Update;

namespace Update.Characters {
	public class Player : MovingCharacter {

		private bool keydown;

		public override Movement GetMovement(){
			float horiz = Input.GetAxis ("Horizontal");
			float vert = Input.GetAxis("Vertical");
			return MovementExtension.ToMovement (horiz, vert);
		}

		public override bool GetAction(){
			bool res = keydown;
			keydown = false;
			return res;
		}

		// capture the keypress from the frame
		public void Update(){
			keydown = keydown || Input.GetKeyDown (KeyCode.Space);
		}

		public void MoveTo(Vector pos){
			index = pos;
		}
	}
}
