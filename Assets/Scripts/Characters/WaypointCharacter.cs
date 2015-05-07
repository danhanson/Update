using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Update;

namespace Update.Characters {
	public class WaypointCharacter : MovingCharacter {

		private int i;

		public List<Vector> waypoints;

		public override void Start ()
		{
			base.Start ();
			i = 0;
		}

		// Update is called once per frame
		protected override Movement GetMovement ()
		{
			Vector waypoint = waypoints [i];
			if (index.Equals(waypoint)) {
				if(++i == waypoints.Count)
					i = 0;
				waypoint = waypoints[i];
			}
			return MovementExtension.ToMovement (waypoint - index);
		}
	}
}
