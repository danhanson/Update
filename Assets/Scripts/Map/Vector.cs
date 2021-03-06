
using System;

namespace Update {

	[System.Serializable]
	public class Vector : IEquatable<Vector> {
		public int X;
		public int Y;
		public Vector(int x, int y){
			this.X = x;
			this.Y = y;
		}
	
		public static Vector operator+(Vector v1, Vector v2){
			return new Vector(v1.X+v2.X,v1.Y + v2.Y);
		}
	
		public static Vector operator*(int i, Vector v){
			return new Vector(v.X*i, v.Y*i);
		}
	
		public static Vector operator*(Vector v, int i){
			return i * v;
		}
		
		public static Vector operator-(Vector v1, Vector v2){
			return new Vector(v1.X - v2.X, v1.Y - v2.Y);
		}

		public override string ToString(){
			return "("+X+","+Y+")";
		}

		public bool Equals(Vector o){
			return (o.X == X) && (o.Y == Y);
		}
	}
}
