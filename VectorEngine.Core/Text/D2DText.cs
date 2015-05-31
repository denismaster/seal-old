using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D2D = SharpDX.Direct2D1;
using DW = SharpDX.DirectWrite;
namespace Seal.Text
{
    public class D2DText:IText
    {
        private DW.TextLayout compiledText;
        private String text;

        public D2DText(string text)
        {
            this.text = text;
            compiledText = GetTextLayout(text, "Arial");
        }
        private static DW.TextLayout GetTextLayout(string text, string fontName)
        {
            return new DW.TextLayout(D2D.Instanse.DWFactory, text, new DW.TextFormat(D2D.Instanse.DWFactory, fontName, 14),100,100);
        }

        public string Value
        {
            get
            {
                return text;
            }
            set
            {
                if(!String.IsNullOrEmpty(value))
                {
                    text = value;
                    compiledText = GetTextLayout(text, "Segoe UI");
                }

            }
        }

        public void Draw(Location location,Drawing.IDrawingContext dc)
        {
            var xdc = dc as Drawing.DrawingContext;
            xdc.D2DTarget.DrawTextLayout(location, compiledText, xdc.StrokeBrush);
        }
    }
}
