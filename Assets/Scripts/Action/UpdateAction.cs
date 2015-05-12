
using UnityEngine;

namespace Update.Action {

	public abstract class UpdateAction : MonoBehaviour {

		public string actionName;

		// add stuff here to add action to level
		// so that the level remains changed
		public abstract void Apply();
	}
}
