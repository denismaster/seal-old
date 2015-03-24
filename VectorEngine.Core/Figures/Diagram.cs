using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SharpDX;
namespace Seal2D.Core.Figures
{
    public abstract class Diagram
    {
        public abstract void Add(Figure f);
        public abstract void Add(LineBase l);
        public abstract Figure FindFigureByPoint(Point p);
        
        public ICollection<LineBase> Lines
        {
            get;
            set;
        }
        public ICollection<Figure> Figures
        {
            get;
            set;
        }
        public ICollection<Group> Groups
        {
            get;
            set;
        }
        public Figure SelectedFigure
        {
            get;
            set;
        }
        public abstract Figure Extend(Figure f);
    }

}
