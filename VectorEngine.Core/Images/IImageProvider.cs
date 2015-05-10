using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seal.Images
{
    public interface IImageProvider
    {
        IImage Get(string filename);
    }
}
