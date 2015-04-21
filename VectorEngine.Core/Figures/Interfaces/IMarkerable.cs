using System;
namespace Seal.Figures
{
    public interface IMarkerable
    {
        System.Collections.Generic.LinkedList<Marker> CreateMarkers();
    }
}
