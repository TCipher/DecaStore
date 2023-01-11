using DecaStore.Data.IRepository;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DecaStore.Models
{
    public class Genre : IEntityBase
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Genre Name is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Genre Name must be between 3 and 50 chars")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description  is Required")]
        public string Description { get; set; }
        public ICollection<Album> Albums { get; set; }

    }
}
