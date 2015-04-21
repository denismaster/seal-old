using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seal.Figures
{
    public class EndLineMarker : Seal.Figures.Marker
    {
        private readonly int pointIndex;
        private readonly Func<SharpDX.Point, Figure> FindByPoint;

        public EndLineMarker(Func<SharpDX.Point, Figure> FindDelegate, int pointIndex)
        {
            this.pointIndex = pointIndex;
            this.FindByPoint = FindDelegate;
        }

        public int PointIndex
        {
            get { return pointIndex; }
        }
        public override void UpdateLocation()
        {
            Line line = targetFigure as Line;
            if (line.From == null || line.To == null)
                return;
            var figure = pointIndex == 0 ? line.From : line.To;
            Location = new Location(figure.LineEnd.X, figure.LineEnd.Y);
        }
        private SharpDX.Point LocationToPoint(Location l)
        {
            var x = Convert.ToInt32(System.Math.Round(l.X));
            var y = Convert.ToInt32(System.Math.Round(l.Y));
            return new SharpDX.Point(x, y);
        }
        public override void Offset(float dx, float dy)
        {
            base.Offset(dx, dy);
            var figure = this.FindByPoint(LocationToPoint(this.Location)) as ILineEndable;
            Line line = targetFigure as Line;
            if (figure == null)
                figure = this;
            if (line.From == figure || line.To == figure)
                return;
            if (pointIndex == 0)
            {
                line.From = figure;
            }
            else
            {
                line.To = figure;
            }
        }
    }
}
