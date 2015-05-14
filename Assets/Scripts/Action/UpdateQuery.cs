
using UnityEngine;

namespace Update.Action {

	public abstract class UpdateQuery : MonoBehaviour {

		public string queryName;

		public abstract string Apply();

	}
}
