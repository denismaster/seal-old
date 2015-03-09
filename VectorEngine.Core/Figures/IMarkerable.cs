using System;
namespace Seal2D.Core.Figures
{
    interface IMarkerable
    {
        System.Collections.Generic.ICollection<Marker> CreateMarkers();
    }
}
