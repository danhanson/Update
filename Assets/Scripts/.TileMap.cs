using UnityEngine;
using System.Collections;
using Update;

namespace Update {
	public class TileMap : MonoBehaviour
	{
		private static Tile[,] resize(Tile[,] src, int w, int h){
			Tile[][] dst = new Tile[h,w];
			for(int i = 0; i < Mathf.Min(h,src.Length); i++)
			    for(int j = 0; j < Mathf.Min(w,src[0].Length); j++)
			    	dst[i,j] = src[i,j];
		}

		public TileSet tileSet;

		public TileMap(TileSet tileSet, int width, int height){
			this.tiles = new Tile[width,height];
			this.tileSet = tileSet;
		}

		public TileMap(){
			this (0, 0, 0, 0);
		}

		private Tile[,] tiles;

		public int height {
			get { return tiles.getLength(0); }
			set { if(height != value) resize(width,value); }
		}

		public int width {
			get { return tiles.getLength(1); }
			set { if(width != value) resize(value,height); }
		}

		public void Resize(int width, int height){
			if(tiles.getLength(0) != width || tiles.getLength(1) != hwight)
				tiles = resize (tiles, height, width);
		}

		public Tile this[int x, int y]{
			get { return tiles [x] [y];}
			set { tiles[x][y] = value}
		}
}
