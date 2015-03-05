using System;
using System.Collections.Generic;
using SharpDX;

namespace Seal2D.Core.Figures
{
    public class ObjectDiagram:Diagram 
    {
        public ObjectDiagram()
        {
            Lines = new LinkedList<Line>();
            Figures = new LinkedList<Figure>();
        }
        public override void Add(Figure f)
        {
            Figures.Add(f);
        }
        public override void Add(Line l)
        {
            Lines.Add(l);
        }
        public override Figure FindFigureByPoint(Point p)
        {
            foreach(var f in Figures)
            {
                if (f.IsPointInside(p)) return f;
            }
            foreach (var l in Lines)
            {
                if (l.IsPointInside(p)) return l;
            }
            return null;
        }
    }
}
