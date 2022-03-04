using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace VRPApplicationCERG.Converters
{
    class ConvertisseurImage : IValueConverter
    {

        /// <summary>
        /// Convertisseur d'i'mage
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                ImageSource retSource = null;

                try
                {
                    if (value != null)
                    {
                        retSource = ImageSource.FromStream(() => new MemoryStream((byte[])value));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ByteToImageFieldConverter Exception: {ex.Message}");
                }

                return retSource ?? "user.png";
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                 => throw new NotImplementedException();
    }
}

