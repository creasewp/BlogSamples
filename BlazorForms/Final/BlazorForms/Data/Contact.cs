using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BlazorForms.Data
{
    public class Contact
    {
        [Required(ErrorMessage = "Please provide a first name.")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }

        private string? _Email { get; set; }

        [EmailAddress]
        [AllowNull]
        public string? Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                this._Email = string.IsNullOrWhiteSpace(value) ? null : value;
            }
        }
    }
}
