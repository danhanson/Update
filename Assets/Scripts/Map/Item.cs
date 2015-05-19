using UnityEngine;
using System.Collections;
using Update;
using Update.Map;
using System;
using Update.Characters;

namespace Update.Map
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class Item : InMap, ActionListener
	{
		// Use this for initialization
		public string identifier;

		public virtual void Start ()
		{
			//PlayerPrefs.DeleteAll ();
			tile ().item = this;
			string name = gameObject.name;
			if (PlayerPrefs.GetInt (name + identifier) == 1) {
				gameObject.SetActive (false);
			}
		}

		public void OnAction(Character c){
			//Do a small dialog

			//add to inventory
			int count = 0;
			string name = gameObject.name;
			if (PlayerPrefs.HasKey (name)) {
				count = PlayerPrefs.GetInt (name);
			}
			PlayerPrefs.SetInt (name, count + 1);
			print ("You've collected " + (count + 1) + " " + name + "s.");
			PlayerPrefs.SetInt (name + identifier, 1);
			//PlayerPrefs.SetInt(gameObject.name,

			//Remove item
			Destroy(gameObject);
		}
	}
}
