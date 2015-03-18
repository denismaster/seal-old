﻿using System;
using System.Collections.Generic;
using System.Linq;
namespace Seal2D.Core.Figures
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
        public override bool IsPointInside(SharpDX.Point p)
        {
            foreach (var f in Childs)
            {
                if (f.IsPointInside(p)) return true;
            }
            return false;
        }

        public override void Draw(Drawing.DrawingContext dc)
        {
            //nothing to do, childs draw manually.
        }
         public void Offset(int dx, int dy)
        {
            foreach (var f in Childs.OfType<IMoveable>())
                f.Offset(dx, dy);
            if (FigureMoved != null)
            {
                FigureMoved(null, new LocationEventsArgs(Location.X, Location.Y));
            }

        }
         public SharpDX.Point Location
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
