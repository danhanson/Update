using UnityEngine;

namespace Update.Characters {
	public enum Movement {
		STANDING,LEFT,RIGHT,UP,DOWN
	}

	public static class MovementExtension
	{
		public static int Vertical(this Movement m){
			switch (m) {
			case Movement.DOWN:
				return -1;
			case Movement.UP:
				return 1;
			default:
				return 0;
			}
		}
	
		public static int Horizontal(this Movement m){
			switch (m) {
			case Movement.LEFT:
				return -1;
			case Movement.RIGHT:
				return 1;
			default:
				return 0;
			}
		}
		
		public static Vector DirectionVector(this Movement m){
			switch (m) {
			case Movement.DOWN:
				return new Vector (0, -1);
			case Movement.LEFT:
				return new Vector (-1, 0);
			case Movement.RIGHT:
				return new Vector (1, 0);
			case Movement.UP:
				return new Vector (0, 1);
			default:
				return new Vector (0, 0);
			}
		}
	
		public static Movement ToMovement(int x, int y){
			int horiz = x.CompareTo (0);
			int vert = y.CompareTo (0);
			switch (horiz) {
			case -1:
				return Movement.LEFT;
			case 1:
				return Movement.RIGHT;
			default:
				switch (vert) {
				case -1:
					return Movement.DOWN;
				case 1:
					return Movement.UP;
				default:
					return Movement.STANDING;
				}
			}
		}
	
		public static Movement ToMovement(this Vector v){
			return ToMovement (v.X, v.Y);
		}
	
		public static Movement ToMovement(float x, float y){
			return ToMovement (x.CompareTo (0), y.CompareTo (0));
		}

		public static Movement ToMovement(this Vector3 v){
			return ToMovement (v.x, v.y);
		}
	}
}