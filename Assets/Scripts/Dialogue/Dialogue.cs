using UnityEngine;

namespace Update.Dialogue {

	public abstract class Dialogue : MonoBehaviour {

		public GameObject managerObject;
		public GameObject nextDialogue;
		protected DialogueManager manager;
		protected Dialogue next;

		public abstract void Apply ();

		public void Start(){
			manager = managerObject.GetComponent<DialogueManager> ();
			if(nextDialogue != null)
				next = nextDialogue.GetComponent<Dialogue> ();
		}
	}
}
