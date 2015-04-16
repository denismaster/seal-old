using System;
namespace Seal2D.Core.Figures
{
    public interface IMarkerable
    {
        System.Collections.Generic.LinkedList<Marker> CreateMarkers();
    }
}
