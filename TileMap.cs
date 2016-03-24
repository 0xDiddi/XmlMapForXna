using System;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;

namespace XmlMap {

    [XmlRoot("TileMap")]
    public class TileMap {

        [XmlAttribute("width")]
        public int Width { get; set; }

        [XmlAttribute("height")]
        public int Height { get; set; }

		[XmlArray("Layers")]
		[XmlArrayItem("Layer", typeof(MapLayer))]
		public MapLayer[] Layers { get; set; }

		public Tile[][] Layer_1 { get; set; }
		public Tile[][] Layer_2 { get; set; }

		public void ColumnsTo2dArray() {
            Layer_1 = new Tile[Width][];
            Layer_2 = new Tile[Width][];

            foreach (var layer in Layers) {
				if (layer.Id == 1) {
					for (int x = 0; x < Width; x++) {
                        Layer_1[x] = new Tile[Height];
						for (int y = 0; y < Height; y++) {
							Layer_1[x][y] = layer.Columns[x].Tiles[y];
                            Layer_1[x][y].HasCollision = Layer_1[x][y].Collision != null;
						}
					}
                } else if (layer.Id == 2) {
                    for (int x = 0; x < Width; x++) {
                        Layer_2[x] = new Tile[Height];
                        for (int y = 0; y < Height; y++) {
                            Layer_2[x][y] = layer.Columns[x].Tiles[y];
                            Layer_2[x][y].HasCollision = Layer_2[x][y].Collision != null;
                        }
                    }
				}
			}
		}

        public void InitLayersWidthHeight(int width, int height) {
            this.Layer_1 = new Tile[width][];
            this.Layer_2 = new Tile[width][];

            for (int i = 0; i < width; i++) {
                Layer_1[i] = new Tile[height];
                Layer_2[i] = new Tile[height];
            }
        }

    }

	[Serializable()]
    public class MapLayer {

		[XmlAttribute("id")]
        public int Id { get; set; }

        [XmlArray("Columns")]
		[XmlArrayItem("TileColumn", typeof(TileColumn))]
        public TileColumn[] Columns { get; set; }

    }

	[Serializable()]
    public class TileColumn {

        [XmlArray("Tiles")]
		[XmlArrayItem("Tile", typeof(Tile))]
        public Tile[] Tiles { get; set; }

    }

	[Serializable()]
    public class Tile {

        [XmlAttribute("name")]
        public String Name { get; set; }

        [XmlAttribute("texture")]
        public String Texture { get; set; }

        public bool HasCollision { get; set; }

        [XmlElement("collision")]
        public TileCollision Collision { get; set; }

        [XmlElement("texture-offset")]
        public TileTextureOffset Texture_offset { get; set; }
    }

    public class TileCollision {

        [XmlAttribute("x")]
        public int X { get; set; }

        [XmlAttribute("y")]
        public int Y { get; set; }

        [XmlAttribute("width")]
        public int Width { get; set; }

        [XmlAttribute("height")]
        public int Height { get; set; }

        public Vector4 toVector4() {
            return new Vector4(this.X, this.Y, this.Width, this.Height);
        }

        public static TileCollision fromVector4(Vector4 v) {
            TileCollision tc = new TileCollision();
            tc.X = (int) v.X;
            tc.Y = (int) v.Y;
            tc.Width = (int) v.Z;
            tc.Height = (int) v.W;
            return tc;
        }

    }

    public class TileTextureOffset {

        [XmlAttribute("x")]
        public int X { get; set; }

        [XmlAttribute("y")]
        public int Y { get; set; }

        public Vector2 toVector2() {
            return new Vector2(this.X, this.Y);
        }

        public static TileTextureOffset fromVector2(Vector2 v) {
            TileTextureOffset tto = new TileTextureOffset();
            tto.X = (int) v.X;
            tto.Y = (int) v.Y;
            return tto;
        }

    }
}

