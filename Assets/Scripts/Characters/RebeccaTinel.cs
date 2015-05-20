using UnityEngine;

namespace Update.Characters {
	class RebeccaTinel : StationaryCharacter {

		private bool busy = false;

		public override void Start(){
			base.Start ();
			if (PlayerPrefs.GetInt("TimePassed")<1440){
				//gameObject.GetComponent<SpriteRenderer>().enabled = false;
				gameObject.SetActive(false);
			}

		}

		public void setBusy(bool busy){
			this.busy = busy;
		}

		public bool getBusy(){
			return this.busy;
		}
	}
}
