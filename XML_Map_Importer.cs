using System;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace XmlMap {

	[ContentImporter(".xml", DisplayName="XML Map Importer")]
	public class XML_Map_Importer : ContentImporter<TileMap> {
        
		public override TileMap Import (string filename, ContentImporterContext context) {
            context.Logger.LogMessage("Importing tilemap from file: {0}", filename);

            XmlSerializer deserializer = new XmlSerializer(typeof(TileMap));
            try {
                FileStream str = new FileStream(filename, FileMode.Open);
                TileMap map = (TileMap)deserializer.Deserialize(str);
                context.Logger.LogMessage("Succesfully imported map!");
                return map;
            } catch (Exception e) {
                context.Logger.LogImportantMessage("Importing the map failed due to the following reason: ");
                context.Logger.LogImportantMessage(e.Message);
            }

            return null;
		}

    }

}