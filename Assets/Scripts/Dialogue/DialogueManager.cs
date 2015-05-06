using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using Update.Characters;

namespace Update.Dialogue {

	public class DialogueManager : MonoBehaviour {

		// we may need to add special scripts to some of these
		public GameObject playerObj;
		public GameObject portrait;
		public GameObject options;
		public GameObject history;

		private UnityAction onSpace;

		public GameObject dialogueBox;
		public GameObject option;

		private Image portraitImage;
		private Player player;

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
			GameObject box = Instantiate (dialogueBox);
			Text t = box.GetComponent<Text>();
			t.text = label + ": "+textStr;
			box.transform.SetParent(history.transform);
			onSpace = callback;
			box.SetActive (true);
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
			foreach (Transform child in history.transform) {
				Destroy(child.gameObject);
			}
		}

		public void Start(){
			portraitImage = portrait.GetComponent<Image> ();
			onSpace = null;
			player = playerObj.GetComponent<Player> ();
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
