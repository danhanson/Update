using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using Update.Characters;

namespace Update.Dialogue {

	// XXX: Make sure the scene has an event system somewhere
	// for this to work
	public class DialogueManager : MonoBehaviour {

		// we may need to add special scripts to some of these
		public GameObject playerObj;
		public GameObject portrait;
		public GameObject options;

		private UnityAction onSpace;

		public GameObject textObj;
		public GameObject option;

		private Image portraitImage;
		private Player player;
        private Text text;

		// TODO add transition
		public Sprite portraitSprite {
			get { return portraitImage.sprite; }
			set { portraitImage.sprite = value; }
		}

		public void AddDialogue(string label, string textStr, Dialogue next = null){
			AddDialogue (label, textStr, next ? next.Apply : (UnityAction) null);
		}

		// TODO animate adding text
		public void AddDialogue(string label, string textStr, UnityAction callback){
			gameObject.SetActive (true);
			player.enabled = false;
			if(label != null && label != "")
				text.text += label + ": "+textStr + "\n\n";
			else
				text.text += textStr + "\n\n";
			onSpace = callback;
		}
		
		public void AddOption(string label, Dialogue result){
			AddOption(label,result.Apply);
		}

		public void AddOption(string label, UnityAction onClick){
			gameObject.SetActive (true);
			player.enabled = false;
			GameObject opt = Instantiate (option);
			Text t = opt.GetComponentInChildren<Text> ();
			t.text = label;
			Button b = opt.GetComponent<Button> ();
			b.onClick.AddListener (onClick);
			b.onClick.AddListener (ClearOptions);
			opt.transform.SetParent (options.transform);
			opt.SetActive (true);
		}

		public void ClearOptions(){
			foreach (Transform child in options.transform) {
				Destroy(child.gameObject);
			}
		}

		public void ClearHistory(){
            text.text = "";
		}

		public void Start(){
			portraitImage = portrait.GetComponent<Image> ();
			onSpace = null;
			player = playerObj.GetComponent<Player> ();
            text = textObj.GetComponent<Text>();
			gameObject.SetActive (false);
		}

		public void Quit(){
			player.enabled = true;
			gameObject.SetActive (false);
			ClearHistory ();
			ClearOptions ();
			onSpace = null;
		}

		public void Update(){
			if (Input.GetKeyDown (KeyCode.Space)) {
				if(onSpace != null){
					// call only once ever
					onSpace ();
				}
			}
		}
	}
}
