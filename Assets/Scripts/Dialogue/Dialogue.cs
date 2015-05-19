
using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Events;
using Update.Action;
using Update.Characters;

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

		protected SortedDictionary<string,UpdateAction> actionDict;
		protected SortedDictionary<string,Sprite> portraitDict;
		protected SortedDictionary<string,UpdateQuery> queryDict;

		protected DialogueManager manager;
		protected Character character;
		protected UnityAction quit;
		protected string speaker;
		protected delegate void ReadXML(XmlNode node, Dialogue d, UnityAction onFinished);

		public void Apply(){
			XmlDocument xml = new XmlDocument ();
			xml.LoadXml (xmlFile.text);
			character.enabled = false;
			Parse (xml.SelectSingleNode("/dialogue").FirstChild,this,quit);
		}

		protected static void Parse(XmlNode node, Dialogue d, UnityAction onFinished){
			if (node != null)
				try {
					//Debug.Log(node.Name);
					parser [node.Name] (node, d, onFinished);
				} catch(KeyNotFoundException e){
					throw new XmlException("Invalid node name: \""+node.Name+"\"",e);
				}
			else if(onFinished != null)
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

		protected static string getAttr(XmlNode node, string attr){
			XmlAttribute a = node.Attributes[attr];
			if(a == null)
				return null;
			else
				return a.InnerText.Trim();
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
						string question = getAttr(node,"value");
						string qspeaker = getAttr(node,"speaker");
						string speaker = (qspeaker == null || qspeaker == "") ? d.speaker : qspeaker;
                        if(question != null && question != "")
							d.manager.AddDialogue(speaker,question);
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
                            Parse(theNode.NextSibling, d, d.quit);
							return;
                        }
                    }
                    if(theNode == null){
                        d.quit();
                        throw new XmlException("No Label Tage found with text=\""+node.InnerText.Trim());
                    }
                }
			},
            { "quit", delegate(XmlNode node, Dialogue d, UnityAction onFinished){
                   d.quit();
                }
            },
            { "label", delegate(XmlNode node, Dialogue d, UnityAction onFinished){
                    Parse(node.NextSibling,d,onFinished);
                }
            },
			{ "query", delegate(XmlNode node, Dialogue d, UnityAction onFinished){
					XmlAttribute name = node.Attributes["name"];
					if(name == null)
						throw new XmlException("Query has no name");
					UpdateQuery q = d.queryDict[name.InnerText.Trim()];
					if(q == null)
						throw new XmlException("No query with name \""+name);
					string ans = q.Apply();
					XmlNode next = null;
					XmlNode def = null;
					UnityAction afterCase = delegate{
							Parse(node.NextSibling,d,onFinished);
						};

					foreach(XmlNode child in node.ChildNodes){
						if(child.Name == "default"){
							def = child;
						} else if(child.Name == "case"){
							if(ans == child.Attributes["value"].InnerText.Trim()){
								next = child;
								Parse(next.FirstChild,d,afterCase);
								return;
							}
						} else {
							Parse(next,d,null);
						}
					}
					if(next == null){
						if(def == null){
							throw new XmlException("Unresolved case: "+ans);
						} else {
							Parse(def.FirstChild,d,afterCase);
						}
					}
				}
			},
			{ "case", delegate(XmlNode node, Dialogue d, UnityAction onFinished){
					throw new XmlException("case node must be direct child of query node");
				}
			},
			{ "default", delegate(XmlNode node, Dialogue d, UnityAction onFinished){
					throw new XmlException("default node must be direct child of query node");
				}
			},
			{ "#comment", delegate(XmlNode node, Dialogue d, UnityAction onFinished){
					Parse(node.NextSibling, d, onFinished);
				}
			}
		};
		
		public void Start(){
			manager = managerObject.GetComponent<DialogueManager>();
			character = gameObject.GetComponent<Character>();
			quit = delegate{
				manager.Quit();
				character.enabled = true;
			};
			portraitDict = new SortedDictionary<String, Sprite> ();
			foreach (Portrait p in portraits) {
				portraitDict [p.name] = p.sprite;
			}
			actionDict = new SortedDictionary<String, UpdateAction> ();
			foreach (UpdateAction a in GetComponents<UpdateAction>()) {
				actionDict[a.actionName] = a;
			}
			queryDict = new SortedDictionary<String, UpdateQuery> ();
			foreach (UpdateQuery q in GetComponents<UpdateQuery>()){
				queryDict[q.queryName] = q;
			}
		}
	}
}
