using EnumBindablePickerSample.Enumerations;
using System.ComponentModel;

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


        private SampleEnum selectedEnum;
        public SampleEnum SelectedEnum
        {
            get { return selectedEnum; }
            set {
                selectedEnum = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedEnum"));  }
        }

        private SampleEnumWithDescription selectedEnumWithDescription;
        public SampleEnumWithDescription SelectedEnumWithDescription
        {
            get { return selectedEnumWithDescription; }
            set {
                selectedEnumWithDescription = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedEnumWithDescription")); }
        }

        private SampleEnumLocalized selectedEnumLocalized;
        public SampleEnumLocalized SelectedEnumLocalized
        {
            get { return selectedEnumLocalized; }
            set
            {
                selectedEnumLocalized = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedEnumLocalized"));
            }
        }


    }
}
