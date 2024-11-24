using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals.Selectors
{
    public class EvenSelector : DataTemplateSelector
    {
        public DataTemplate? EvenTemplate { get; set; }
        public DataTemplate? OddTemplate { get; set; }
        protected override DataTemplate? OnSelectTemplate(object item, BindableObject container)
        {
            if (item.ToString()?.Length % 2 == 0) return EvenTemplate;
            return OddTemplate;
        }
    }
}
