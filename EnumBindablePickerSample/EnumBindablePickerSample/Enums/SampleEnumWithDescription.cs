using System.ComponentModel.DataAnnotations;

namespace EnumBindablePickerSample.Enums
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
