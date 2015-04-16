using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seal2D.Core.Figures;
namespace Seal2D.Core.IO
{
    public interface IDiagramSerializer
    {
        void Save(string Filename, Diagram d);
        Diagram Load(string Filename);
    }
}
