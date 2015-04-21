using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Seal.Figures;
namespace Seal.IO
{
    public class XmlDiagramSerializer : IDiagramSerializer
    {
        public void Save(string filename, Diagram d)
        {
            XmlSerializer s = new XmlSerializer(d.GetType());
            System.IO.StreamWriter stream = new System.IO.StreamWriter(filename);
            s.Serialize(stream, d);
            stream.Close();
        }
        public Diagram Load(string filename)
        {
            System.IO.StreamReader stream = new System.IO.StreamReader(filename);
            XmlSerializer s = new XmlSerializer(Type.GetType("Seal.Figures.Diagram"));
            return (Diagram)s.Deserialize(stream);
        }
    }
}
