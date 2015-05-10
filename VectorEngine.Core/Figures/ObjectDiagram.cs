using System;
using System.Collections.Generic;
using SharpDX;

namespace Seal.Figures
{
    public class ObjectDiagram:Diagram
    {
        public ObjectDiagram()
        {
            Figures = new LinkedList<Figure>();
            Groups = new LinkedList<Group>();
        }
        public override void Add(Figure f)
        {
            Figures.AddLast(f);
        }
        public override void Add(LineBase l)
        {
            Figures.AddLast(l);
        }
        public override Figure Get(Point p)
        {
            for (var node = Groups.Last; node != null;node=node.Previous)
            {
                if (node.Value.IsPointInside(ref p)) return node.Value;
            }
            for (var node = Figures.Last; node != null; node = node.Previous)
            {
                if (node.Value.IsPointInside(ref p)) return node.Value;
            }
            return null;
        }
        public override Figure Extend(Figure f)
        {
            //if (f is SolidFigure)
            //    f = new SolidExtend(f as SolidFigure);
            return f;
        }
        public override void Delete(Figure f)
        {
            if(f is Group)
            {
                var g = f as Group;
                foreach(var q in g.Childs)
                {
                    Figures.Remove(q);
                }
                if(Groups.Contains(g))
                {
                    Groups.Remove(g);
                }
            }
            if (Figures.Contains(f))
                Figures.Remove(f);
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
