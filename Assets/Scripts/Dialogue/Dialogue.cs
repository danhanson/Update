
using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Events;
using Update.Action;

namespace Update.Dialogue {

	public class Dialogue : MonoBehaviour {

		[System.Serializable]
		public class Portrait
		{
			public string name;
			public Sprite sprite;
		}

		public Portrait[] portraits;

		public TextAsset xmlFile;
		public GameObject managerObject;

		private SortedDictionary<string,UpdateAction> actionDict;
		private SortedDictionary<string,Sprite> portraitDict;

		private DialogueManager manager;
		private string speaker;
		protected delegate void ReadXML(XmlNode node, Dialogue d);

		public void Apply(){
			XmlDocument xml = new XmlDocument ();
			xml.LoadXml (xmlFile.text);
			Parse (xml.SelectSingleNode("/dialogue").FirstChild,this);
		}

		private static void Parse(XmlNode node, Dialogue d){
			if (node == null)
				d.manager.Quit ();
			else
				parser [node.Name] (node, d);
		}

		protected static UnityAction ParseNext(XmlNode node, Dialogue d){
			if (node == null)
				return d.manager.Quit;
			return delegate {
				Parse (node, d);
			};
		}

		protected static SortedDictionary<string,ReadXML> parser = new SortedDictionary<string,ReadXML>
		{
			{ "text", delegate(XmlNode node, Dialogue d){
					d.manager.AddDialogue(d.speaker,node.InnerText.Trim(),ParseNext(node.NextSibling, d));
				}
			},
			{ "portrait", delegate(XmlNode node, Dialogue d){
					d.manager.portraitSprite = d.portraitDict[node.InnerText.Trim()]; Parse(node.NextSibling,d);
				}
			},
			{ "speaker",  delegate(XmlNode node, Dialogue d){
					d.speaker = node.InnerText.Trim();
					Parse(node.NextSibling,d);
				}
			},
			{ "question", delegate(XmlNode node, Dialogue d){
					string question = node.Attributes["value"].InnerText;
					d.manager.AddDialogue(d.speaker,question.Trim());
					foreach(XmlNode child in node.ChildNodes){
						Parse(child,d);
					}
					}
				},
			{ "answer",  delegate(XmlNode node, Dialogue d){
						d.manager.AddOption(node.Attributes["label"].InnerText.Trim(),ParseNext(node.FirstChild, d));
					}
				},
			{ "action", delegate(XmlNode node, Dialogue d){
					UpdateAction action = d.actionDict[node.InnerText.Trim()];
					action.Apply();
					Parse (node.NextSibling,d);
				}
			}
		};
		
		public void Start(){
			manager = managerObject.GetComponent<DialogueManager>();
			portraitDict = new SortedDictionary<String, Sprite> ();
			foreach (Portrait p in portraits) {
				portraitDict [p.name] = p.sprite;
			}
			actionDict = new SortedDictionary<String, UpdateAction> ();
			foreach (UpdateAction a in GetComponents<UpdateAction>()) {
				actionDict[a.actionName] = a;
			}
		}
	}

}
