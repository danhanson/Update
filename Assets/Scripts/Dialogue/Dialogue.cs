
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
		protected delegate void ReadXML(XmlNode node, Dialogue d, UnityAction onFinished);

		public void Apply(){
			XmlDocument xml = new XmlDocument ();
			xml.LoadXml (xmlFile.text);
			Parse (xml.SelectSingleNode("/dialogue").FirstChild,this,manager.Quit);
		}

		private static void Parse(XmlNode node, Dialogue d, UnityAction onFinished){
			if (node != null)
				parser [node.Name] (node, d, onFinished);
			else
				onFinished();
		}

		protected static UnityAction ParseNext(XmlNode node, Dialogue d, UnityAction onFinished){
			if(node != null)
				return delegate {
					Parse (node, d, onFinished);
				};
			else
				return onFinished;
		}

		protected static SortedDictionary<string,ReadXML> parser = new SortedDictionary<string,ReadXML>
		{
			{ "text", delegate(XmlNode node, Dialogue d, UnityAction onFinished){
					d.manager.AddDialogue(
							d.speaker,node.InnerText.Trim(),
							ParseNext(node.NextSibling, d, onFinished)
						);
				}
			},
			{ "portrait", delegate(XmlNode node, Dialogue d, UnityAction onFinished){
					d.manager.portraitSprite = 
						d.portraitDict[node.InnerText.Trim()];
					Parse(node.NextSibling,d,onFinished);
				}
			},
			{ "speaker",  delegate(XmlNode node, Dialogue d, UnityAction onFinished){
					d.speaker = node.InnerText.Trim();
					Parse(node.NextSibling,d,onFinished);
				}
			},
			{ "question", delegate(XmlNode node, Dialogue d, UnityAction onFinished){
						string question = node.Attributes["value"].InnerText;
						d.manager.AddDialogue(d.speaker,question.Trim());
						UnityAction afterQuestion = delegate{
							Parse(node.NextSibling,d,onFinished);
						};
						foreach(XmlNode child in node.ChildNodes){
							Parse(child,d,afterQuestion);
						}
					}
				},
			{ "answer",  delegate(XmlNode node, Dialogue d, UnityAction onFinished){
						d.manager.AddOption(
								node.Attributes["label"].InnerText.Trim(),
								ParseNext(node.FirstChild, d, onFinished)
							);
				}
			},
			{ "action", delegate(XmlNode node, Dialogue d, UnityAction onFinished){
					UpdateAction action = d.actionDict[node.InnerText.Trim()];
					action.Apply();
					Parse (node.NextSibling,d,onFinished);
				}
            },
            { "jump", delegate(XmlNode node, Dialogue d, UnityAction onFinished){
                    XmlNodeList labelNodes = node.OwnerDocument.GetElementsByTagName("label");
                    XmlNode theNode = null;
                    foreach(XmlNode labelNode in labelNodes){
                        if(labelNode.InnerText.Trim() == node.InnerText.Trim()){
                            theNode = labelNode;
                            Parse(theNode.NextSibling, d, d.manager.Quit);
                        }
                    }
                    if(theNode == null){
                        d.manager.Quit();
                        throw new XmlException("No Label Tage found with text=\""+node.InnerText.Trim());
                    }
                }
			},
            { "quit", delegate(XmlNode node, Dialogue d, UnityAction onFinished){
                   d.manager.Quit();
                }
            },
            { "label", delegate(XmlNode node, Dialogue d, UnityAction onFinished){
                    Parse(node.NextSibling,d,onFinished);
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
