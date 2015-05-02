// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.17020
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

using Update;

namespace Update.Map
{
	public class TileMap
	{
		private Tile[,] tiles;

		public TileMap(int w, int h){
			tiles = new Tile[w, h];
		}

		public Tile this[Vector index]
		{
			get { return tiles [index.X, index.Y]; }
			set { tiles [index.X, index.Y] = value; }
		}

		public Tile this [int x, int y] {
			get { return tiles [x, y]; }
			set { tiles [x, y] = value; }
		}
	}
}

