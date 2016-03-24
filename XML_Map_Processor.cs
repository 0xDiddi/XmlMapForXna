using System;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace XmlMap {

    [ContentProcessor(DisplayName="XML Map Processor")]
    public class XML_Map_Processor : ContentProcessor<TileMap, TileMap> {

        public override TileMap Process(TileMap input, ContentProcessorContext context) {
            context.Logger.LogMessage("Processing map...");

            input.ColumnsTo2dArray();

            context.Logger.LogMessage("Done processing map.");

            return input;
        }

    }

}