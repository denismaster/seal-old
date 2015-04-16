using System;
using Newtonsoft.Json;

namespace Seal2D.Core
{
    
    public struct Location
    {
        private float _x;
        private float _y;
        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = (value < 0) ? 0 : value;
            }
        }
        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = (value < 0) ? 0 : value;
            }
        }
        public Location(float X, float Y)
        {
            _x = 0;
            _y = 0;
            this.X = X;
            this.Y = Y;
        }
        public static implicit operator SharpDX.Vector2(Location d)
        {
            return new SharpDX.Vector2(d.X, d.Y);
        }
    }
}
