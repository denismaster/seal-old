using System;
using System.Collections.Generic;
namespace Seal2D.Core.Figures
{
    public class Group : Figure
    {
        public ICollection<Figure> Childs
        {
            get;
            set;
        }
    
        public override bool IsPointInside(SharpDX.Point p)
        {
            foreach (var f in Childs)
                if (f.IsPointInside(p)) return true;
            return false;
        }

        public override void Draw(Drawing.DrawingContext dc)
        {
            //nothing to do, childs draw manually.
        }

        public void Add(Figure f)
        {
            Childs.Add(f);
        }
    }
}
