using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GastosApp.Behaviors
{
    public class DatePickerBehavior : Behavior<DatePicker>
    {
        DatePicker datePicker;
        protected override void OnAttachedTo(DatePicker bindable)
        {
            base.OnAttachedTo(bindable);
            datePicker = bindable;
            datePicker.DateSelected += DatePicker_DateSelected;
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            DatePicker date = (DatePicker)sender;
            Application.Current.MainPage.DisplayAlert("Error", date.Date.ToString(), "Ok");
        }

        protected override void OnDetachingFrom(DatePicker bindable)
        {
            base.OnDetachingFrom(bindable);
            datePicker.DateSelected -= DatePicker_DateSelected;
        }
    }
}
