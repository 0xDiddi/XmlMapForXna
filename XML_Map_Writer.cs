using System;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace XmlMap {

    [ContentTypeWriter]
    public class XML_Map_Writer : ContentTypeWriter<TileMap> {

        protected override void Write(ContentWriter output, TileMap value) {

            Console.WriteLine("Writing Map...");

            output.Write(value.Width);
            output.Write(value.Height);

            Console.WriteLine("Writing layer 1...");

            foreach (var ta in value.Layer_1) {
                foreach (var t in ta) {
                    output.Write(t.Name);
                    output.Write(t.Texture);
                    if (!t.Name.Equals("null")) {
                        output.Write(t.Texture_offset.toVector2());
                        output.Write(t.HasCollision);
                        if (t.HasCollision)
                            output.Write(t.Collision.toVector4());
                    }
                }
            }

            Console.WriteLine("Done writing layer 1.");
            Console.WriteLine("Writing layer 2...");

            foreach (var ta in value.Layer_2) {
                foreach (var t in ta) {
                    output.Write(t.Name);
                    output.Write(t.Texture);
                    if (!t.Name.Equals("null")) {
                        output.Write(t.Texture_offset.toVector2());
                        output.Write(t.HasCollision);
                        if (t.HasCollision)
                            output.Write(t.Collision.toVector4());
                    }
                }
            }
            Console.WriteLine ("Done Writing layer 2.");

            output.Flush();
        }

        public void PrintStuff(Object stuff) {
            Console.WriteLine((stuff == null));
            Console.WriteLine(stuff);
        }

        public override string GetRuntimeType(TargetPlatform targetPlatform) {
            return typeof(TileMap).AssemblyQualifiedName;
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform) {
            return typeof(XML_Map_Reader).AssemblyQualifiedName;
        }

    }

}