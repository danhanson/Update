
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

namespace Update.Action {

	[System.Serializable]
	public class LevelManager {

		public const int NUM_LEVELS = 10;

		public static LevelManager Instance {
			get { return manager; }
		}

		[System.Serializable]
		protected class Level {

			[SerializeField]
			private List<ActionFunctor> actions;

			public Level(){
				actions = new List<ActionFunctor>();
			}

			public void RecordAction(ActionFunctor action){
				actions.Add(action);
			}

			public void ApplyActions(){
				foreach(ActionFunctor action in actions){
					action.Apply();
				}
			}
		}

		[SerializeField]
		private Level[] levels;

		private static LevelManager manager = new LevelManager(NUM_LEVELS);

		private LevelManager(int numLevels){
			levels = new Level[numLevels];
			for(int i = 0; i < numLevels; i++){
				levels[i] = new Level();
			}
		}

		public void OnLevelWasLoaded(int level){
			levels[level].ApplyActions();
		}

		public static void RecordAction(int level, LevelAction action){
			RecordAction(level,action.Functor);
		}

		public static void RecordAction(int level, ActionFunctor action){
			Instance.levels[level].RecordAction(action);
		}
	}
}

