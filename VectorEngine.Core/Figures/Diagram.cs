using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;
using SharpDX;
using SharpDX.Direct2D1;
namespace Seal.Figures
{
    [Serializable]
    public abstract class Diagram
    {
        public abstract void Add(Figure f);
        public abstract void Add(LineBase l);
        public abstract Figure Extend(Figure f);
        public abstract Figure FindFigureByPoint(Point p);
        public abstract void BringToFront(Figure f);
        public abstract void SendToBack(Figure f);
        public LinkedList<LineBase> Lines
        {
            get;
            set;
        }
        public LinkedList<Figure> Figures
        {
            get;
            set;
        }
        public LinkedList<Group> Groups
        {
            get;
            set;
        }
        [XmlIgnore]
        [JsonIgnore]
        public Figure SelectedFigure
        {
            get;
            set;
        }
        
    }

}
