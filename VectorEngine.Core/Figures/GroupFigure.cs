using System;
using System.Collections.Generic;
using System.Linq;
namespace Seal.Figures
{
    public abstract class Group : Figure
    {
        public ICollection<Figure> Childs
        {
            get;
            set;
        }
        public abstract void Add(Figure t);
    }
    public class GroupFigure : Group, IMoveable
    {
        public GroupFigure()
        {
            Childs = new LinkedList<Figure>();
        }
        public override bool IsPointInside(ref SharpDX.Point p)
        {
            foreach (var f in Childs)
            {
                if (f.IsPointInside(ref p)) return true;
            }
            return false;
        }

        public override void Draw(Drawing.DrawingContext dc)
        {
            //nothing to do, childs draw manually.
        }
        public void Offset(float dx, float dy)
        {
            foreach (var f in Childs.OfType<IMoveable>())
                f.Offset(dx, dy);

        }
        public Location Location
        {
            get;
            set;
        }
        public event EventHandler<LocationEventsArgs> FigureMoved;

        public virtual void OnFigureMove(object sender, LocationEventsArgs e)
        {
            if (FigureMoved != null)
            {
                FigureMoved(sender, e);
            }
        }
        public override void Add(Figure f)
        {
            Childs.Add(f);
        }
    }
}
