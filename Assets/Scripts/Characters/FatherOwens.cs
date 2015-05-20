using UnityEngine;

namespace Update.Characters {
	class FatherOwens : StationaryCharacter {

		public int stage = 0;
		private bool busy = false;
		private bool firstSermon = false;
		private bool secondSermon = false;
		private int reputation = 0;
		private bool knowsAboutRobby = false;
		private bool stopped = false;

		public override void Start(){
			base.Start ();
			if (stage == 0) {
				if (PlayerPrefs.GetInt("TimePassed")>2057){
					//gameObject.GetComponent<SpriteRenderer>().enabled = false;
					gameObject.SetActive(false);
				}
			}
			if (stage == 2) {
				//gameObject.GetComponent<SpriteRenderer>().enabled = false;
				gameObject.SetActive(false);
			}
			if (stage == 3) {
				//GameObject.Find ("Gunshot").gameObject.transform.GetChild(0).gameObject.SetActive(false);
				if (PlayerPrefs.GetInt("TimePassed")<3085){
					//gameObject.GetComponent<SpriteRenderer>().enabled = false;
					gameObject.SetActive(false);
				}
			}
		}

		public void setBusy(bool busy){
			this.busy = busy;
		}

		public bool getBusy(){
			return this.busy;
		}

		public void setFirstSermon(bool firstSermon){
			this.firstSermon = firstSermon;
		}
		
		public bool getFirstSermon(){
			return this.firstSermon;
		}
		
		public void setSecondSermon(bool secondSermon){
			this.secondSermon = secondSermon;
		}
		
		public bool getSecondSermon(){
			return this.secondSermon;
		}
		
		public void setReputation(int rep){
			this.reputation += rep;
		}
		
		public int getReputation(){
			return this.reputation;
		}
		
		public void setRobby(bool robby){
			this.knowsAboutRobby = robby;
		}
		
		public bool getRobby(){
			return this.knowsAboutRobby;
		}
		
		public void setStopped(bool stopped){
			this.stopped = stopped;
		}
		
		public bool getStopped(){
			return this.stopped;
		}
		


	}
}
