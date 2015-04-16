using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seal2D.Core.Figures
{
    //Представляет возможность работы с объектами как с объектами VectorEditor
    public abstract class VectorObject
    {
        
        private string _name = String.Empty;
        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                if(!String.IsNullOrEmpty(value))
                {
                    _name = value;
                }
            }
        }
    }
}
