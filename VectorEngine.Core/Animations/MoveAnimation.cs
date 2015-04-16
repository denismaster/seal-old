using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
                var length = vector.Length();
                vector.Normalize();
                float dx, dy;
                dx = vector.X;
                dy = vector.Y;
                Task moveTask = new Task(() =>
                {
                    var i = 0.0f;
                    while (length>=i)
                    {
                        m.Offset(-dx, -dy);
                        Thread.Sleep(1);
                        i+=1;
                    }
                });
                moveTask.Start();
            }
        }

    }
}
