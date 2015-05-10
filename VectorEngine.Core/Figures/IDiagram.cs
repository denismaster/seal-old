using System;
namespace Seal.Figures
{
    interface IDiagram
    {
        void Add(Figure f);
        void Add(LineBase l);
        void BringToFront(Figure f);
        void Delete(Figure f);
        Figure Get(SharpDX.Point p);
        void SendToBack(Figure f);
    }
}
