using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seal.Controllers
{
    public interface IControllerFactory
    {
        Seal.Figures.Diagram Diagram
        {
            get;
        }
        Controller Get<T>();
    }
}
