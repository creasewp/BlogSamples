using System.ComponentModel;
using EnumBindablePickerSample.Enums;

namespace EnumBindablePickerSample.ViewModels
{
    public class PickerSamplePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public PickerSamplePageViewModel()
        {
            //set default value
            SelectedEnum = SampleEnum.Three;
            SelectedEnumWithDescription = SampleEnumWithDescription.Two;
            SelectedEnumLocalized = SampleEnumLocalized.One;
        }


        private SampleEnum _selectedEnum;
        public SampleEnum SelectedEnum
        {
            get => _selectedEnum;
            set {
                _selectedEnum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedEnum"));
            }
        }

        private SampleEnumWithDescription _selectedEnumWithDescription;
        public SampleEnumWithDescription SelectedEnumWithDescription
        {
            get => _selectedEnumWithDescription;
            set {
                _selectedEnumWithDescription = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedEnumWithDescription"));
            }
        }

        private SampleEnumLocalized _selectedEnumLocalized;
        public SampleEnumLocalized SelectedEnumLocalized
        {
            get => _selectedEnumLocalized;
            set
            {
                _selectedEnumLocalized = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedEnumLocalized"));
            }
        }
    }
}
