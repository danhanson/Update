
using UnityEngine;

namespace Update.Action {

	// generic action that can be triggerred by dialogue
	[System.Serializable]
	public abstract class UpdateAction : MonoBehaviour {

		public string actionName;

		public abstract void Apply();
	}

	// generic Action that is inteded to changes the map
	[System.Serializable]
	public abstract class BigAction : UpdateAction {

		public int Level {
			get;
			internal set;
		}

		private bool saved;

		public override void Apply(){
			if(!saved){
				LevelManager.RecordAction(this);
				saved = true;
			}
		}

		public void Awake(){
			saved = false;
			DontDestroyOnLoad(this);
		}

		public void OnLevelWasLoaded(int level){
			if(!saved)
				this.Level = level;
		}
	}
}
