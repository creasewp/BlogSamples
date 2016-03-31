using EnumBindablePickerSample.ViewModels;
using Xamarin.Forms;

namespace EnumBindablePickerSample.Views
{
    public partial class PickerSamplePage : ContentPage
    {
        public PickerSamplePage()
        {
            InitializeComponent();
            BindingContext = new PickerSamplePageViewModel();
        }
    }
}
