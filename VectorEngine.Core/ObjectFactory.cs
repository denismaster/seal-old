﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX;
using Seal2D.Core.Figures;
namespace Seal2D.Core
{
    public class ObjectFactory
    {
        public ObjectFactory()
        {
        }
        public Figure Extend(Figure f)
        {
            if (f is SolidFigure)
                f = new SolidExtend(f as SolidFigure);
            return f;
        }
        public T CreateFigure<T>(Point where)
            where T : SolidFigure, new()
        {
            throw new NotImplementedException();
        }
    }
}