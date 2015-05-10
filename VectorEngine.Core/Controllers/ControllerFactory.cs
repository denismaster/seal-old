using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seal.Controllers
{
    public class ControllerFactory : IControllerFactory
    {
        private readonly Figures.Diagram _diagram;
        private Dictionary<Type, Controller> _controllers;

        public ControllerFactory(Figures.Diagram d)
        {
            if (d != null)
            {
                _diagram = d;
                _controllers = new Dictionary<Type, Controller>();
            }
            else
                throw new ArgumentNullException();
        }

        public Figures.Diagram Diagram
        {
            get
            {
                return _diagram;
            }
        }


        public Controller Get<T>()
        {
            var type = typeof(T);
            if(_controllers.ContainsKey(type))
            {
                return _controllers[type];
            }
            else
            {
                var c = (Controller)Activator.CreateInstance(type, Diagram);
                _controllers.Add(type, c);
                return c;
            }
        }
    }
}
