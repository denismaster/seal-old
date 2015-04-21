using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seal.Figures
{
    public class ControlMarker : Seal.Figures.Marker
    {
        public ControlMarker(int pointIndex)
        {
            this.pointIndex = pointIndex;
        }
        public ControlMarker(int pointIndex, SharpDX.Vector2 Position)
        {
            this.pointIndex = pointIndex;
            this.Location = new Location(Position.X, Position.Y);
        }
        private int pointIndex;

        public override void UpdateLocation()
        {
            IPointControllable line = targetFigure as IPointControllable;
            if (line != null)
            {
                Location = (Location)line.GetPoint(pointIndex);
            }
            base.OnFigureMove(this, new MarkerEventArgs(this.Location.X, this.Location.Y, this.pointIndex));

        }

        public override void Offset(float dx, float dy)
        {
            base.Offset(dx, dy);
            base.OnFigureMove(this, new MarkerEventArgs(this.Location.X, this.Location.Y, this.pointIndex));
        }
    }
}
