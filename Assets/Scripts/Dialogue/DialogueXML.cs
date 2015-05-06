

using System.Xml;
using UnityEngine;
using UnityEngine.Events;

namespace Update.Dialogue {
	
	public abstract class DialogueXML : MonoBehaviour {

		public Sprite[] portraits;
		public UnityEvent[] events;
		public XmlDocument xml;

		public void Apply(){

		}
	}
}
