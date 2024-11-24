using DocumentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentApp.Selectors
{
    public class DocumentTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Folder { get; set; }
        public DataTemplate File { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var document = (Document)item;
            if (document.IsFolder) return Folder;
            return File;
        }
    }
}
