using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seal.Text;
namespace Seal.Figures.Interfaces
{
    public interface ITextable
    {
        bool HasText
        {
            get;
        }
        IText Text
        {
            get;
            set;
        }
    }
    public class MyGeometry:SharpDX.Direct2D1.PathGeometry,Seal.Geometries.IFilledGeometry
    {
        public MyGeometry():base(D2D.Instanse.D2DFactory)
        {
            var g = this.Open();
            g.BeginFigure(new Location(0, 0), SharpDX.Direct2D1.FigureBegin.Filled);
            g.AddLine(new Location(50, 0));
            g.AddLine(new Location(90, 30));
            g.AddLine(new Location(0, 50));
            g.EndFigure(SharpDX.Direct2D1.FigureEnd.Closed);
            g.Close();
            g.Dispose();
        }
        public Size Size
        {
            get
            {
                var p = this.GetBounds();
                return new Seal.Size(p.Width,p.Height);
            }
            set
            {
                float scaleX=1,scaleY=1;
                if(Size.Width!=null)
                scaleX = value.Width/Size.Width;
                if(Size.Height!=null)
                scaleY = value.Height/Size.Height;
                
            }
        }

        public bool Contains(ref SharpDX.Point p)
        {
            return StrokeContainsPoint(p, 1) || FillContainsPoint(p);
        }

        public void Draw(Drawing.IDrawingContext dc, SharpDX.Vector2 where, int strokeWidth = 1)
        {
            var xdc = dc as Drawing.DrawingContext;
            xdc.Translate(where.X, where.Y);
            xdc.D2DTarget.DrawGeometry(this, xdc.StrokeBrush);
            xdc.IdentityTransform();
        }
    }
}
