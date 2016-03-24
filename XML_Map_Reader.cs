using System;
using Microsoft.Xna.Framework.Content;

namespace XmlMap {
    
    public class XML_Map_Reader : ContentTypeReader<TileMap> {
        
        protected override TileMap Read(ContentReader input, TileMap Instance) {
            int Width = input.ReadInt32(), Height = input.ReadInt32();

            Instance = new TileMap();

            Instance.Width = Width;
            Instance.Height = Height;
            Instance.InitLayersWidthHeight(Width, Height);

            for (int X = 0; X < Width; X++) {
                for (int Y = 0; Y < Height; Y++) {
                    Tile T = new Tile();
                    T.Name = input.ReadString();
                    T.Texture = input.ReadString();
                    if (!T.Name.Equals("null")) {
                        T.Texture_offset = TileTextureOffset.fromVector2(input.ReadVector2());
                        T.HasCollision = input.ReadBoolean();
                        if (T.HasCollision)
                            T.Collision = TileCollision.fromVector4(input.ReadVector4());
                    }
                    Instance.Layer_1[X][Y] = T;
                }
            }

            for (int X = 0; X < Width; X++) {
                for (int Y = 0; Y < Height; Y++) {
                    Tile T = new Tile();
                    T.Name = input.ReadString();
                    T.Texture = input.ReadString();
                    if (!T.Name.Equals("null")) {
                        T.Texture_offset = TileTextureOffset.fromVector2(input.ReadVector2());
                        T.HasCollision = input.ReadBoolean();
                        if (T.HasCollision)
                            T.Collision = TileCollision.fromVector4(input.ReadVector4());
                    }
                    Instance.Layer_2[X][Y] = T;
                }
            }

            return Instance;

        }

    }
}