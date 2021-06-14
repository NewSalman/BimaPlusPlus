using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BimaPlus.Extension
{
    public class Carousel : IMarkupExtension<Color>
    {

        public string[] path;


        public Color ProvideValue(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException();
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException();
        }
    }
}
