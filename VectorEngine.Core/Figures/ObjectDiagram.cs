using System;
using System.Collections.Generic;
using SharpDX;

namespace Seal.Figures
{
    public class ObjectDiagram:Diagram 
    {
        public ObjectDiagram()
        {
            Lines = new LinkedList<LineBase>();
            Figures = new LinkedList<Figure>();
            Groups = new LinkedList<Group>();
        }
        public override void Add(Figure f)
        {
            Figures.AddLast(f);
        }
        public override void Add(LineBase l)
        {
            Lines.AddLast(l);
        }
        public override Figure FindFigureByPoint(Point p)
        {
            foreach (var f in Groups)
            {
                if (f.IsPointInside(ref p)) return f;
            }
            foreach(var f in Figures)
            {
                if (f.IsPointInside(ref p)) return f;
            }
            foreach (var l in Lines)
            {
                if (l.IsPointInside(ref p)) return l;
            }
            return null;
        }
        public override Figure Extend(Figure f)
        {
            if (f is SolidFigure)
                f = new SolidExtend(f as SolidFigure);
            return f;
        }

        public override void BringToFront(Figure f)
        {
                Figures.Remove(f);
                Figures.AddLast(f);
        }

        public override void SendToBack(Figure f)
        {
                Figures.Remove(f);
                Figures.AddFirst(f);
        }
    }
}
