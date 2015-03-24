using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Seal2D.Core.Figures;
namespace Seal2D.Core.Animations
{
    public class MoveAnimation : Animation
    {
        private int x, y;
        public MoveAnimation(Figure f, int x, int y)
            : base(f)
        {
            this.x = x;
            this.y = y;
        }
        public int X
        {
            get { return x; }
        }
        public int Y
        {
            get { return y; }
        }

        public override void Execute()
        {
            IMoveable m = Target as IMoveable;
            if (m != null)
            {
                var vector = new SharpDX.Vector2(m.Location.X - X, m.Location.Y - Y);
                vector.Normalize();
                int dx, dy;
                dx = Convert.ToInt32(Math.Round(vector.X));
                dy = Convert.ToInt32(Math.Round(vector.Y));
                Thread moveTask = new Thread(() =>
                {
                    for (int i = 0; i < 100;i++ )
                        m.Offset(dx, dy);
                });
                moveTask.Start();
            }
        }

    }
}
