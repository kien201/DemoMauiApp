using Microsoft.Maui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals.CustomControls
{
    class DatePickerNullable : DatePicker
    {
        public static readonly BindableProperty DateNullableProperty = BindableProperty.Create(
            nameof(DateNullable), 
            typeof(DateTime?), 
            typeof(DatePickerNullable), 
            defaultBindingMode: BindingMode.TwoWay, 
            propertyChanged: DateNullablePropertyChanged);

        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
            nameof(Placeholder), 
            typeof(string), 
            typeof(DatePickerNullable), 
            "--/--/----");

        public DateTime? DateNullable
        {
            get { return (DateTime?)GetValue(DateNullableProperty); }
            set { SetValue(DateNullableProperty, value); }
        }

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        static void DateNullablePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var picker = (DatePickerNullable)bindable;
            if (picker.DateNullable.HasValue)
                picker.Date = picker.DateNullable.Value;
        }
    }
}
