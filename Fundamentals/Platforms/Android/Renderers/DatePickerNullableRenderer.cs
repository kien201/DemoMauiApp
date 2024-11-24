using Android.Content;
using Fundamentals.CustomControls;
using Fundamentals.Platforms.Android.Renderers;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals.Platforms.Android.Renderers
{
    class DatePickerNullableRenderer : DatePickerRenderer
    {
        public DatePickerNullableRenderer(Context context) : base(context)
        {
        }

        //protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        //{
        //    base.OnElementChanged(e);

        //    if (Control != null && e.NewElement != null)
        //    {
        //        var picker = (DatePickerNullable)e.NewElement;
        //        if (!picker.DateNullable.HasValue) 
        //            Control.Text = picker.Placeholder;
        //    }
        //}
    }
}
