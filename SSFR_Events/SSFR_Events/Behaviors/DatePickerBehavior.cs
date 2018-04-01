using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SSFR_Events.Behaviors
{
    public class DatePickerBehavior : Behavior<DatePicker>
    {

        public static readonly BindableProperty CommandProp = BindableProperty.Create("Command", typeof(Command), typeof(DatePickerBehavior), null);

        public static readonly BindableProperty ValueConverterProp = BindableProperty.Create("Converter", typeof(IValueConverter), typeof(DatePickerBehavior), null);

        public Command Command
        {
            get => (Command)GetValue(CommandProp);

            set => SetValue(CommandProp, value); 
        }

        public IValueConverter Converter
        {
            get => (IValueConverter)GetValue(ValueConverterProp);

            set => SetValue(CommandProp, value);
        }

        public DatePicker obj { get; private set; }

        protected override void OnAttachedTo(DatePicker bindable)
        {
            base.OnAttachedTo(bindable);

            obj = bindable;

            bindable.BindingContextChanged += OnBindingContextChanged;

            bindable.DateSelected += OnDateSelected;

        }

        protected override void OnDetachingFrom(DatePicker bindable)
        {
            base.OnDetachingFrom(bindable);

            bindable.BindingContextChanged -= OnBindingContextChanged;

            bindable.DateSelected -= OnDateSelected;

            obj = null;
            
        }
        
        private void OnDateSelected(object sender, DateChangedEventArgs e)
        {
            if (Command == null)
            {
                return;
            }

            object param = Converter.Convert(e, typeof(object), null, null);

            if (Command.CanExecute(param))
            {
                Command.Execute(param);
            }

        }

        void OnBindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = obj.BindingContext;
        }

    }
}
