using System;
namespace Seal2D.Core.Figures
{
    public interface IMarkerable
    {
        System.Collections.Generic.ICollection<Marker> CreateMarkers();
    }
}
