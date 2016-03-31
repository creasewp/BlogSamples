using System.ComponentModel.DataAnnotations;

namespace EnumBindablePickerSample.Enumerations
{
    public enum SampleEnumWithDescription
    {
        [Display(Description = "First")]
        One,
        [Display(Description = "Second")]
        Two,
        [Display(Description = "Third")]
        Three
    }
}
