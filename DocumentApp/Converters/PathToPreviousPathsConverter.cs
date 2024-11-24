using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentApp.Converters
{
    public class PathToPreviousPathsConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var previousPaths = new List<object>();
            var folderNames = value.ToString().TrimEnd('/').Split('/');

            string path = "/";
            foreach (var folderName in folderNames)
            {
                path = Path.Combine(path, folderName);
                previousPaths.Add(new
                {
                    Name = string.IsNullOrEmpty(folderName) ? "/" : folderName,
                    Path = path
                });
            }
            return previousPaths;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
