// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.17020
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using UnityEngine;
using Update;
using Update.Map;

namespace Update
{
	public class InMap : MonoBehaviour
	{
		public Vector index {
			get {
				Vector3 pos = transform.position;
				return new Vector ((int)pos.x, (int)pos.y);
			}
			set {
				Vector3 pos = transform.position;
				transform.position = new Vector3(value.X,value.Y,pos.z);
			}
		}

		public Tile tile(){
			return GameData.map[index];
		}
	}
}

