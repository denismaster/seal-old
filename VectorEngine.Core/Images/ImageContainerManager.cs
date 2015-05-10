using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frosya2.Objects
{
    public class ImageContainerManager:IDisposable 
    {
        public SharpDX.Direct2D1.RenderTarget WICTarget { get; set; }
        public SharpDX.Direct2D1.RenderTarget HwndTarget { get; set; }

        internal Dictionary<string, ImageContainer> ImageContainerList { get; set; }

        public ImageContainer this[string key]
        {
            get
            {
                return ImageContainerList[key];
            }
        }

        public string this[ImageContainer key]
        {
            get
            {
                var keys = from e in ImageContainerList
                           where e.Value == key
                           select e.Key;
                string filename = keys.First();
                keys = null;
                return filename;
            }
        }

        public ImageContainerManager(SharpDX.Direct2D1.RenderTarget wicTarget, SharpDX.Direct2D1.RenderTarget hwndTarget)
        {
            ImageContainerList = new Dictionary<string, ImageContainer>();
            HwndTarget = hwndTarget;
            WICTarget = wicTarget;
        }
        public void Dispose()
        {
            foreach(ImageContainer f in ImageContainerList.Values)
            {
                f.Dispose();
            }
            ImageContainerList = null;
        }

        public ImageContainer Add(string filename)
        {
            if (ImageContainerList.ContainsKey(filename))
            {
                return this[filename];
            }
            else
            {
                if (HwndTarget != null && WICTarget != null && System.IO.File.Exists(filename))
                {
                    ImageContainer imContainer = new ImageContainer(filename, WICTarget, HwndTarget);
                    ImageContainerList.Add(filename, imContainer);
                    return imContainer;
                }
                else
                {
                    return null;
                }
            }
        }

        public void Delete(string filename)
        {
            if (ImageContainerList.ContainsKey(filename))
            {
                ImageContainerList.Remove(filename);
            }
        }
    }
}
