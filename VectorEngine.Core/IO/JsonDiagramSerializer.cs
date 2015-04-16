using System;
using System.Collections.Generic;
using Seal2D.Core.Figures;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace Seal2D.Core.IO
{
    public class JsonDiagramSerializer : IDiagramSerializer
    {
        public void Save(string filename, Diagram d)
        {
            System.IO.StreamWriter s = new System.IO.StreamWriter(filename);
            string json = JsonConvert.SerializeObject(d, Formatting.Indented, new JsonSerializerSettings()
                {
                    //TypeNameHandling = TypeNameHandling.Objects
                });
            s.Write(json);
            s.Close();
        }
        public Diagram Load(string filename)
        {
            System.IO.StreamReader s = new System.IO.StreamReader(filename);
            string json = s.ReadToEnd();
            return JsonConvert.DeserializeObject<Diagram>(json, new JsonSerializerSettings()
                {
                    //TypeNameHandling = TypeNameHandling.Objects
                });
        }
    }
}
