using UnityEngine;

namespace Update.Characters {
	class Mayor : StationaryCharacter {

		public int stage = 0;
		private bool middle = false;
		private bool end = false;

		public override void Start(){
			base.Start ();
			if (stage == 3) {
				if (PlayerPrefs.GetInt ("TimePassed") < 3085) {
					gameObject.GetComponent<SpriteRenderer>().enabled = false;
					//gameObject.SetActive(false);
					tile().character = null;
				}
			}
			if (PlayerPrefs.GetInt ("TimePassed") < 2057) {
				gameObject.GetComponent<SpriteRenderer> ().enabled = false;
				//gameObject.SetActive(false);
				tile().character = null;
			}
		}

		public void setMiddle(bool middle){
			this.middle = middle;
		}

		public bool getMiddle(){
			return this.middle;
		}

		public void setEnd(bool end){
			this.end = end;
		}

		public bool getEnd(){
			return this.end;
		}
	}
}
