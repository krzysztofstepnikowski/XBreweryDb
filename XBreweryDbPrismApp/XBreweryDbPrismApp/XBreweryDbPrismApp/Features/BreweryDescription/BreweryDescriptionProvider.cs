using System;

namespace XBreweryDbPrismApp.Features.BreweryDescription
{
    public class BreweryDescriptionProvider
    {
        private const string LoremIpsum = @"Lorem ipsum dolor sit amet leo. Aenean pellentesque accumsan. 
                     Fusce wisi semper eu, neque. Sed at erat volutpat.Pellentesque egestas blandit, quam.
                     Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.
                     Mauris ornare ultrices velit sit amet erat.Vestibulum ante at laoreet metus facilisis nunc, fringilla sit amet mauris consequat eu,
                     posuere cubilia Curae, Donec est. Integer mi libero, egestas at, accumsan augue varius nunc iaculis in, libero.
                     Praesent rutrum. In laoreet metus semper risus nibh condimentum est iaculis odio consequat ac, vestibulum quis, l
                     acinia scelerisque, dui lectus pharetra eget, lacinia ut, lectus.Nam hendrerit. Fusce nulla. Aenean tincidunt tempus.
                     Pellentesque sagittis, nunc interdum dui lectus at ipsum. Nam eu justo.Pellentesque molestie sagittis.Lorem ipsum dolor sit amet leo. 
                     Aenean pellentesque accumsan.
                     Fusce wisi semper eu, neque.Sed at erat volutpat. Pellentesque egestas blandit, quam.
                     Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.
                     Mauris ornare ultrices velit sit amet erat.Vestibulum ante at laoreet metus facilisis nunc, fringilla sit amet mauris consequat eu,
                     posuere cubilia Curae, Donec est. Integer mi libero, egestas at, accumsan augue varius nunc iaculis in, libero.
                     Praesent rutrum. In laoreet metus semper risus nibh condimentum est iaculis odio consequat ac, vestibulum quis, l
                     acinia scelerisque, dui lectus pharetra eget, lacinia ut, lectus.Nam hendrerit. Fusce nulla. Aenean tincidunt tempus.
                     Pellentesque sagittis, nunc interdum dui lectus at ipsum. Nam eu justo.Pellentesque molestie sagittis.";

        public string GetBreweryDescription(string breweryId)
        {
            return $"Description for {breweryId}{Environment.NewLine}{LoremIpsum}";
        }
    }
}
