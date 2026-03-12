using System.ComponentModel.DataAnnotations;

namespace SampleBlazorApp.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "City is required!")]
        public string City { get; set; }

        [Required(ErrorMessage = "Country is required!")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Gender is required!")]
        public string Gender { get; set; }
    }
}
