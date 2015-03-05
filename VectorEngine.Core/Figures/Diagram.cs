using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SharpDX;
namespace Seal2D.Core.Figures
{
    public abstract class Diagram
    {
        public abstract void Add(Figure f);
        public abstract void Add(Line l);
        public abstract Figure FindFigureByPoint(Point p);
        public ICollection<Line> Lines
        {
            get;
            set;
        }
        public ICollection<Figure> Figures
        {
            get;
            set;
        }
        public Figure SelectedFigure
        {
            get;
            set;
        }
    }

}
