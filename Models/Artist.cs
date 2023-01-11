using DecaStore.Data.IRepository;
using System.ComponentModel.DataAnnotations;

namespace DecaStore.Models
{
    public class Artist : IEntityBase
    {
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Artist Name is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Artist Name must be between 3 and 50 chars")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Country is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Country must be between 3 and 20 chars")]
        public string Country { get; set; }
    }
}
