
using UnityEngine;
using UnityEngine.Events;

using System.Collections;
using System.Collections.Generic;

namespace Update.Action {

	[System.Serializable]
	public class LevelManager : MonoBehaviour {

		public const int NUM_LEVELS = 10;

		public static LevelManager Instance {
			get { return manager; }
		}

		[System.Serializable]
		protected class Level {
			private List<BigAction> actions;

			public Level(){
				actions = new List<BigAction>();
			}

			public void RecordAction(BigAction action){
				actions.Add(action);
			}

			public void ApplyActions(){
				foreach(BigAction action in actions){
					action.Apply();
				}
			}
		}

		private Level[] levels;

		private static LevelManager manager = new LevelManager(NUM_LEVELS);

		private LevelManager(int numLevels){
			levels = new Level[numLevels];
			for(int i = 0; i < numLevels; i++){
				levels[i] = new Level();
			}
		}

		public void Awake(){
			DontDestroyOnLoad(this);
		}

		// we may have to wait later or something
		public virtual void OnLevelWasLoaded(int level){
			levels[level].ApplyActions();
		}

		public static void RecordAction(BigAction action){
			Instance.levels[action.Level].RecordAction(action);
		}
	}
}
