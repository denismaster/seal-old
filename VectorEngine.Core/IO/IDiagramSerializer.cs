using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seal.Figures;
namespace Seal.IO
{
    public interface IDiagramSerializer
    {
        void Save(string Filename, Diagram d);
        Diagram Load(string Filename);
    }
}
