
using UnityEngine;

namespace Update.Action {

	public class Level : MonoBehaviour {

		public virtual void OnLevelWasLoaded(int level){
			LevelManager.Instance.OnLevelWasLoaded(level);
		}
	}
}
